using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class GameState
{
    public static Player CurrentPlayer = ScriptableObject.CreateInstance<Player>();
    public static bool PlayerReturningHome;
    public static Dictionary<string, Vector3> LastScenePosition = new Dictionary<string, Vector3>();

    public static Vector3 GetLastScenePosition(string sceneName)
    {
        if (GameState.LastScenePosition.ContainsKey(sceneName))
        {
            var lastPos = GameState.LastScenePosition[sceneName];
            return lastPos;
        }
        else return Vector3.zero;
    }

    public static void SetLastScenePosition(string sceneName, Vector3 position)
    {
        if (GameState.LastScenePosition.ContainsKey(sceneName))
        {
            LastScenePosition[sceneName] = position;
        }
        else
            LastScenePosition.Add(sceneName, position);
    }
}
