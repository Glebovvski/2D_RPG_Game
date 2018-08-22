using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyMenu{

	[MenuItem("MenuName/MenuItem1")]
    static void EnableMyAwesomeFeature()
    {
        Debug.Log("I am a leaf on the wind. Watch how i soar.");
    }

    [MenuItem("MenuName/MenuItem1", true)]
    static bool CheckIfAGameObjectIsSelected()
    {
        return Selection.activeTransform != null;
    }

    [MenuItem("MenuName/MenuItem2 %g")]
    static void EnableMyOtherAwesomeFeature()
    {
        Debug.Log("Find my key and win the prize - g");
    }

    [MenuItem("CONTEXT/Transform/Move to Center")]
    static void MoveToCenter(MenuCommand command)
    {
        Transform transform = (Transform)command.context;
        transform.position = Vector3.zero;
        Debug.Log("Moved object to " + transform.position + " from a Context Menu.");
    }
}
