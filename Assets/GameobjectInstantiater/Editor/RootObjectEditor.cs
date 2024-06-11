using System;
using UnityEditor;
using UnityEngine;


#if UNITY_EDITOR
[CustomEditor(typeof(RootObject))]
public class RootObjectEditor : Editor
{

    public override void OnInspectorGUI()
    {
        var rootObject = (RootObject)target;
       
        EditorGUILayout.LabelField("Gameobject Instantiater by JSON", EditorStyles.boldLabel);
        EditorGUILayout.Space(12);
        base.OnInspectorGUI();


        
        

        if (rootObject.editJsonAsString == true)
        {
            if (rootObject.JSONFileToRead == null)
            {
                EditorGUILayout.HelpBox("JSON file need to attach", MessageType.Warning);
            }
        }
        if (GUILayout.Button("Save Data From JSON String", GUILayout.Height(50),GUILayout.Width(250)))
        {
            rootObject.SaveDataFromJsonText();
           
        }

        EditorGUILayout.LabelField("---------------------------------------");

        if (GUILayout.Button("Generate JSON Data", GUILayout.Height(20)))
        {
            rootObject.WriteDataJson();
        }

        if (GUILayout.Button("Load & Read JSON Data", GUILayout.Height(20)))
        {
            rootObject.ReadDataJson();
        }

        if(rootObject.pathToSaveJSON==string.Empty)
        {
            EditorGUILayout.HelpBox("No Path Specified", MessageType.Warning);
        }

        if (rootObject.fileNameToSave == string.Empty)
        {
            EditorGUILayout.HelpBox("File not Specified", MessageType.Warning);
        }

        if (GUILayout.Button("Create Game Object", GUILayout.Height(20)))
        {
            rootObject.CreateGameObjects();
        }

        
    }
}
#endif