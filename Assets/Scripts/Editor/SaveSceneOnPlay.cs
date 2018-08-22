using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class SaveSceneOnPlay {

	static SaveSceneOnPlay()
    {
        EditorApplication.playmodeStateChanged += SaveSceneIfPlaying;
    }

    static void SaveSceneIfPlaying()
    {
        if(EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
        {
            Debug.Log("Automaticly saving scene (" + EditorApplication.currentScene + ") before entering play mode");

            AssetDatabase.SaveAssets();
            //EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(),);
            EditorApplication.SaveScene();
        }
    }
}
