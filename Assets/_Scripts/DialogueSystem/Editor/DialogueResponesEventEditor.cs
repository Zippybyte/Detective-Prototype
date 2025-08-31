using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DialogueResponesEvent))]
public class DialogueResponesEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueResponesEvent responseEvent = (DialogueResponesEvent)target;

        if (GUILayout.Button("Refresh"))
        {
            responseEvent.OnValidate();
        }
    }
}
    
