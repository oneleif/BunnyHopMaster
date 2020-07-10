using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SteamCloudUtil
{
    public static string playerPrefsFileName = "playerPrefs.txt";
    public static void LoadPlayerPrefs()
    {
        if (Steamworks.SteamRemoteStorage.IsCloudEnabled)
        {
            byte[] playerPrefsData = Steamworks.SteamRemoteStorage.FileRead(playerPrefsFileName);
            string decodedPlayerPrefs = Encoding.UTF8.GetString(playerPrefsData);
            PlayerPrefData saveData = JsonUtility.FromJson<PlayerPrefData>(decodedPlayerPrefs);

            OptionsPreferencesManager.SetCameraFOV(saveData.CameraFOV);
            OptionsPreferencesManager.SetFullScreen(saveData.IsFullScreen == 0 ? false : true);
            OptionsPreferencesManager.SetPortalRecursion(saveData.PortalRecursion);
            OptionsPreferencesManager.SetQuality(saveData.Quality);
            OptionsPreferencesManager.SetResolution(saveData.ResolutionWidth, saveData.ResolutionHeight);
            OptionsPreferencesManager.SetSensitivity(saveData.Sensitivity);
            OptionsPreferencesManager.SetVolume(saveData.Volume);
        }
    }

    public static void SavePlayerPrefs()
    {
        if (Steamworks.SteamRemoteStorage.IsCloudEnabled)
        {
            PlayerPrefData saveData = PlayerPrefUtil.GetAllPrefs();
            string playerPrefString = JsonUtility.ToJson(saveData);
            byte[] playerPrefsData = Encoding.UTF8.GetBytes(playerPrefString);
            Steamworks.SteamRemoteStorage.FileWrite(playerPrefsFileName, playerPrefsData);
        }
    }
}
