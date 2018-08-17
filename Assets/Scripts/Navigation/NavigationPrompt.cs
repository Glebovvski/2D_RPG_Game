using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationPrompt : MonoBehaviour
{
    bool showDialog = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (NavigationManager.CanNavigate(this.tag))
            DialogVisible(true);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (NavigationManager.CanNavigate(this.tag))
    //        DialogVisible(true);
    //}

    private void OnTriggerExit2D(Collider2D collider)
    {
        DialogVisible(false);
    }

    void DialogVisible(bool visibility)
    {
        showDialog = visibility;
        MessagingManager.Instance.BroadcastUIEvent(visibility);
    }

    private void OnGUI()
    {
        if (showDialog)
        {
            GUIStyle style = new GUIStyle();
            style.wordWrap = true;
            style.fontStyle = FontStyle.Italic;
            style.normal.textColor = Color.white;
            GUI.color = Color.white;
            GUI.BeginGroup(new Rect(Screen.width / 2, 50, 300, 250), style);

            GUI.Box(new Rect(0, 0, 200, 35), "");
            GUI.Label(new Rect(15, 10, 300, 68), "Travel to " + NavigationManager.GetRouteInfo(this.tag) + " (E)", style);

            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogVisible(false);
                NavigationManager.NavigateTo(this.tag);
            }
            GUI.EndGroup();
        }
    }
}
