using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreatArea))]
[System.Serializable]
public class CreatAreaEditor : Editor
{
    


    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ground"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("xStartPos"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("yStartPos"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("columnSize"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("rowSize"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("xSpace"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ySpace"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("areas"));
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();

        CreatArea area = (CreatArea)target;

        if(GUILayout.Button("Creat All Area"))
        {
            area.CreatAllArea();
        }

        if(GUILayout.Button("Delete All Area"))
        {
            area.DeleteAllArea();
        }





       


    }






}
