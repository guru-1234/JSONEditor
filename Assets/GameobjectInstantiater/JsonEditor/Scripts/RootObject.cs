
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "RootObject", menuName = "JSON Instantiater/RootObject")]
public class RootObject : ScriptableObject
{
    public string pathToSaveJSON;
    public string fileNameToSave;
    public TextAsset JSONFileToRead;
   

    public bool editJsonAsString;
    [ConditionalHide("editJsonAsString", true)]
    [TextArea(25,100)]
    public string jsonAsText;
    private bool onceRefreshed;
    public RootParent rootParent;
    private List<GameObject> _allGameobjects;
    private void OnValidate()
    {           
        if (JSONFileToRead == null)
        {
            onceRefreshed = false;
            Debug.LogWarning("JSON need attach");
            return;
        }

        if(jsonAsText.Length<=0)
        {
            onceRefreshed = false;
            jsonAsText = ConvertTextAssetToString();
            onceRefreshed = true;
        }
        if (!onceRefreshed)
        {
            jsonAsText = ConvertTextAssetToString();
            onceRefreshed = true;
        }


    }
    [System.Serializable]
    public class RootParent
    {
        public Child listOfChilds;
    }
    
    

    [System.Serializable]
    public class Root
    {
        public string name;
        public Position position;
        public Rotation rotation;
        public Scale scale;
        public ColorScale color;
        public UiComponent uIComponent;
        public List<Child> children;

        
    }
    [System.Serializable]
    public class Position
    {
        public double x;
        public double y;
        public double z;
    }
    [System.Serializable]
    public class Rotation
    {
        public double x;
        public double y;
        public double z;
        public double w;
    }

    [System.Serializable]
    public class Scale
    {
        public double x;
        public double y;
        public double z;
        public double w;
    }

    [System.Serializable]
    public class ColorScale
    {
        [Range(0, 255)]
        public double r;
        [Range(0, 255)]
        public double g;
        [Range(0, 255)]
        public double b;
        [Range(0, 255)]
        public double a;
    }

    [System.Serializable]
    public class UiComponent
    {
        public UIComponents component;
    }

    [System.Serializable]
    public enum UIComponents
    {
        None,
        HasImage,
        HasText
    }
    [System.Serializable]
    public class Child
    {
        public string name;
        public string parentName;
        public Position position;
        public Rotation rotation;
        public Scale scale;
        public ColorScale color;
        public UiComponent uIComponent;
        public List<Child> children;
    }

    /// <summary>
    /// Responsible for generating JSON file in desired path
    /// </summary>
    public void WriteDataJson()
    {
        
        string StringData = JsonConvert.SerializeObject(rootParent, Formatting.Indented);
        Debug.Log("Write Data To Json");
        byte[] bytes = Encoding.ASCII.GetBytes(StringData);
        File.WriteAllBytes(pathToSaveJSON + "/" + fileNameToSave+".json", bytes);

    }

    /// <summary>
    /// Used to read JSON from file
    /// </summary>
    public void ReadDataJson()
    {
        
        string jsonString = ConvertTextAssetToString();
        RootParent output = JsonUtility.FromJson<RootParent>(jsonString);
        rootParent = output;
    }

    /// <summary>
    /// Responsible for converting the JSON file to string in JSON format
    /// </summary>
    /// <returns></returns>
    public string ConvertTextAssetToString()
    {
        
        string data = JSONFileToRead.text;
        object JSON_Object = JsonConvert.DeserializeObject(data);
        string JSON_Data_Formatted = JsonConvert.SerializeObject(JSON_Object, Formatting.Indented);
        return JSON_Data_Formatted;
    }


    /// <summary>
    /// Responsible for saving the JSON data from text file to desired path
    /// </summary>
    public void SaveDataFromJsonText()
    {

        if (jsonAsText != null)
        {

            if (IsValidJson(jsonAsText))
            {
                byte[] bytes = Encoding.ASCII.GetBytes(jsonAsText);
                File.WriteAllBytes(pathToSaveJSON + "/" + fileNameToSave + ".json", bytes);
                Debug.LogWarning("JSON is valid");
            }
            else
            {
                Debug.LogWarning("JSON is not valid");
            }

        }
        else
        {
            Debug.LogWarning("JSON Test is not found");
        }
    }


    /// <summary>
    /// USed to valiadate the JSON file
    /// </summary>
    /// <param name="stringValue"></param>
    /// <returns></returns>
    public bool IsValidJson(string stringValue)
    {
        if (string.IsNullOrWhiteSpace(stringValue))
        {
            return false;
        }

        var value = stringValue.Trim();

        if ((value.StartsWith("{") && value.EndsWith("}")) || 
            (value.StartsWith("[") && value.EndsWith("]"))) 
        {
            try
            {
                var obj = JToken.Parse(value);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        return false;
    }

    /// <summary>
    /// Create gameobjects based on JSON data
    /// </summary>
    public void CreateGameObjects()
    {
        bool addCanvasForFirstObject = false;
        Stack<Child> ToDo = new Stack<Child>();

        Child firstChild = rootParent.listOfChilds;
        ToDo.Push(firstChild);
        while (ToDo.Count > 0)
        {
            Child h = ToDo.Pop();
            StackObjects(h, ToDo);
        }


        void StackObjects(Child h, Stack<Child> ToDo)
        {
            Debug.Log( h.name);
            
            if (h.children == null)
                return;
            
            //if(AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("Assets/Prefabs/TestPrefab.prefab")==null)
            //{
            //    Debug.LogWarning("Prefab is not in the desired path");
            //    return;
            //}
            GameObject prefab = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("Assets/GameobjectInstantiater/Prefabs/TestPrefab.prefab"));
            if(!addCanvasForFirstObject)
            {
                prefab.AddComponent<Canvas>();
                prefab.AddComponent<CanvasScaler>();
                addCanvasForFirstObject = true;
            }
            _allGameobjects.Add(prefab);
            prefab.name = h.name;
            Selection.activeGameObject = GettingParent(h.parentName);
            if (Selection.activeTransform != null)
            {
                prefab.transform.SetParent(Selection.activeTransform, false);
            }
            Color32 color = new Color32((byte)h.color.r, (byte)h.color.g, (byte)h.color.b, (byte)h.color.a);
            Vector3 position = new Vector3((int)h.position.x, (int)h.position.y, (int)h.position.z);
            Vector3 rotation = new Vector3((int)h.rotation.x, (int)h.rotation.y, (int)h.rotation.z);
            Vector3 scale = new Vector3((int)h.scale.x, (int)h.scale.y, (int)h.scale.z);
            if (h.uIComponent.component==UIComponents.HasText)
            {
                TextMeshProUGUI text = prefab.AddComponent<TextMeshProUGUI>();
                text.color = color;


            }
            else if(h.uIComponent.component == UIComponents.HasImage)
            {
                Image image =prefab.AddComponent<Image>();
                image.color = color;
            }
            
            RectTransform rect = prefab.GetComponent<RectTransform>();
            rect.localPosition = position;
            rect.localEulerAngles = rotation;
            rect.localScale = scale;
            
            for (int i = h.children.Count - 1; i >= 0; --i)
                ToDo.Push(h.children[i]);
        }
    }

    /// <summary>
    /// Used to check and match parent gameobject
    /// </summary>
    /// <param name="parentName"></param>
    /// <returns></returns>
    private GameObject GettingParent(string parentName)
    {
        GameObject gameObject = null;
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {

            if (go.name == parentName)
            {
                gameObject = go;
                return gameObject;
            }
        }
        return gameObject;
    }
}
