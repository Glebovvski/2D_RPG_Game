using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager {

    public struct Route
    {
        public string RouteDescription;
        public bool CanTravel;
    }

    public static Dictionary<string, Route> RouteInformation = new Dictionary<string, Route>()
    {
        { "World", new Route{RouteDescription= "The big bad world",CanTravel=true } },
        {"Cave01", new Route{RouteDescription= "The deep dark cave",CanTravel=false } },
        {"Shop", new Route { RouteDescription= "Ye Shop", CanTravel=true } },
        {"Town", new Route{ RouteDescription= "The Town",CanTravel=true } },
        {"Kirkidw", new Route{RouteDescription="The grand city of Kirkidw", CanTravel=true} },
        {"Battle", new Route{RouteDescription="Hard Battle", CanTravel=true } }
    };

    public static string GetRouteInfo(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].RouteDescription : null; 
    }

    public static bool CanNavigate(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].CanTravel : false;
    }

    public static void NavigateTo(string destination)
    {
        FadeInOutManager.FadeToLevel(destination, 2f, 2f, Color.black);
    }
}
