using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerPrefUtil
{
    public static string playerPrefFilePath = Path.Combine(Application.persistentDataPath, SteamCloudUtil.playerPrefsFileName);
    public static PlayerPrefData GetAllPrefs()
    {
        string fileData = File.ReadAllText(playerPrefFilePath);
        PlayerPrefData allData = JsonUtility.FromJson<PlayerPrefData>(fileData);
        return allData;
    }

    public static void SaveAllPrefs(PlayerPrefData allData)
    {
        string jsonData = JsonUtility.ToJson(allData);
        File.WriteAllText(playerPrefFilePath, jsonData);
    }
}
