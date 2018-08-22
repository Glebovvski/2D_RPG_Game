using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraLookAt))]
public class CameraTargetEditor : Editor {

    public override void OnInspectorGUI()
    {
        CameraLookAt targetScript = (CameraLookAt)target;

        targetScript.cameraTarget = EditorGUILayout.Vector3Field("Look at point", targetScript.cameraTarget);
        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }

    void OnSceneGUI()
    {
        CameraLookAt targetScript = (CameraLookAt)target;

        targetScript.cameraTarget = Handles.PositionHandle(targetScript.cameraTarget, Quaternion.identity);
        Handles.SphereCap(0, targetScript.cameraTarget, Quaternion.identity, 2);
        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }

    private void OnEnable()
    {
        EditorApplication.hierarchyChanged += HierarchyWindowChanged;
    }

    void HierarchyWindowChanged()
    {

    }

    private void OnDestroy()
    {
        EditorApplication.hierarchyChanged -= HierarchyWindowChanged;
    }
}
