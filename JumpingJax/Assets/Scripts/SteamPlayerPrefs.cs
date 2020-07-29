using Castle.Core.Internal;
using Steamworks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SteamPlayerPrefs : MonoBehaviour
{
    public static SteamPlayerPrefs Instance { get; private set; }
    private const string prefsFileName = "prefs.txt";
    private PlayerPrefModel playerPrefModel;

    void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (SteamPlayerPrefs.Instance == null)
        {
            SteamPlayerPrefs.Instance = this;
        }
        else if (SteamPlayerPrefs.Instance == this)
        {
            Destroy(SteamPlayerPrefs.Instance.gameObject);
            SteamPlayerPrefs.Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    // Queued up after steam has loaded
    public static void LoadPlayerPrefs()
    {
        string fileData = string.Empty;
        if (SteamRemoteStorage.IsCloudEnabled)
        {
            byte[] encodedData = SteamRemoteStorage.FileRead(prefsFileName);
            if(encodedData != null)
            {
                fileData = Encoding.UTF8.GetString(encodedData);
            }
        }
        else
        {
            string filePath = Path.Combine(Application.persistentDataPath, prefsFileName);
            fileData = File.ReadAllText(filePath);
        }

        if (fileData.IsNullOrEmpty())
        {
            Debug.Log("No player prefs, generating with defaults");
            SavePlayerPrefs();
        }
        else
        {
            Debug.Log("Player prefs found, populating from JSON");
            Instance.playerPrefModel = JsonUtility.FromJson<PlayerPrefModel>(fileData);
        }
    }

    public static void SavePlayerPrefs()
    {
        if(Instance.playerPrefModel == null)
        {
            Debug.Log("Trying to save player prefs, but they don't exist, generating new prefs");
            Instance.playerPrefModel = new PlayerPrefModel();
        }
        if (SteamRemoteStorage.IsCloudEnabled)
        {
            string fileData = JsonUtility.ToJson(Instance.playerPrefModel);
            byte[] encodedData = Encoding.UTF8.GetBytes(fileData);
            SteamRemoteStorage.FileWrite(prefsFileName, encodedData);
        }
        else
        {
            string filePath = Path.Combine(Application.persistentDataPath, prefsFileName);
            string fileData = JsonUtility.ToJson(Instance.playerPrefModel);
            File.WriteAllText(filePath, fileData);
        }
            
    }
}
