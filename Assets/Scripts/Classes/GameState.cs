using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public static  class GameState
{
    public static Player CurrentPlayer = ScriptableObject.CreateInstance<Player>();
    public static bool PlayerReturningHome;
    public static Dictionary<string, Vector3> LastScenePosition = new Dictionary<string, Vector3>();

    static string saveFilePath = Application.persistentDataPath + "/playerstate.dat";

    public static bool SaveAvailable
    {
        get { return File.Exists(saveFilePath); }
    }

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

    public static void SaveState()
    {
        try
        {
            PlayerPrefs.SetString("CurrentLocation", SceneManager.GetActiveScene().name);
            var playerSerializedState = SerializationHelper.Serialise<PlayerSaveState>(CurrentPlayer.GetPlayerSaveState());
#if UNITY_METRO
            UnityEngine.Windows.File.WriteAllBytes(saveFilePath, playerSerializedState);
#else
            using (var file=File.Create(saveFilePath))
            {
                file.Write(playerSerializedState, 0, playerSerializedState.Length);
            }
#endif
        }
        catch
        {
            Debug.LogError("Saving data failed");
        }
    }

    public static void LoadState(Action LoadComplete)
    {
        PlayerSaveState loadedPlayer;
        try
        {
            if (SaveAvailable)
            {
#if UNITY_METRO
                var playerSerializedState=UnityEngine.Windows.File.ReadAllBytes(saveFilePath);
                loadedPlayer = SerializationHelper.Deserialise<PlayerSaveState>(playerSerializedState);
#else
                using (var stream=File.Open(saveFilePath, FileMode.Open))
                {
                    loadedPlayer = SerializationHelper.Deserialise<PlayerSaveState>(stream);
                }
#endif
                CurrentPlayer = loadedPlayer.LoadPlayerSaveState(CurrentPlayer);
            }
        }
        catch
        {
            Debug.LogError("Loading data failed, file is corrupt");
        }
        LoadComplete();
    }
}
