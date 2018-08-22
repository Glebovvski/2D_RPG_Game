using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditorWindow : EditorWindow {

    string windowName = "My Editor Window";
    bool groupEnabled;
    bool displayToggle = true;
    float offset = 1.23f;

    [MenuItem("Window/My Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindowWithRect(typeof(MyEditorWindow), new Rect(0, 0, 400, 150));
    }

    private void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        windowName = EditorGUILayout.TextField("Window Name", windowName);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);

        displayToggle = EditorGUILayout.Toggle("Display Toggle", displayToggle);

        offset = EditorGUILayout.Slider("Offset slider", offset, -3, 3);
        EditorGUILayout.EndToggleGroup();
    }
}
