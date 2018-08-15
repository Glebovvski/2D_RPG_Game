using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager {

    public static Dictionary<string, string> RouteInformation = new Dictionary<string, string>()
    {
        { "World","The big bad world" },
        {"Cave","The deep dark cave" }
    };

    public static string GetRouteInfo(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null; 
    }

    public static bool CanNavigate(string destination)
    {
        return true;
    }

    public static void NavigateTo(string destination)
    {
        //SceneManager.LoadScene(destination);
    }
}
