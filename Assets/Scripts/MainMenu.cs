using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {
    bool saveAvailable;
    private void Start()
    {
        saveAvailable = GameState.SaveAvailable;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 100, 200, 200));

        if(GUILayout.Button("New Game"))
        {
            NavigationManager.NavigateTo("Town");
        }
        GUILayout.Space(50);
        if (saveAvailable)
        {
            if(GUILayout.Button("Load Game"))
            {
                GameState.LoadState(() =>
                {
                    var lastLocation = PlayerPrefs.GetString("CurrentLocation", "Town");
                    NavigationManager.NavigateTo(lastLocation);
                });
            }
        }
        GUILayout.EndArea();
    }
}
