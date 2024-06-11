using UnityEngine;
using UnityEditor;

public class JsonEditor : EditorWindow
{
    [MenuItem("Window/JSON Editor")]
    public static void ShowJsonEditor()
    {
        GetWindow<JsonEditor>("JSON Editor");
    }
}
