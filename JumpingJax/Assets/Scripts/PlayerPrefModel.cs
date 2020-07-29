using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefModel
{
    // HotKeys
    public string Forward { get; set; }
    public string Back { get; set; }
    public string Left { get; set; }
    public string Right { get; set; }
    public string Jump { get; set; }
    public string Crouch { get; set; }
    public string ResetLevel { get; set; }
    public string Portal1 { get; set; }
    public string Portal2 { get; set; }

    // Options
    public int ResolutionWidth { get; set; }
    public int ResolutionHeight { get; set; }
    public int Volume { get; set; }
    public int Quality { get; set; }
    public int FullScreen { get; set; }
    public float Sensitivity { get; set; }
    public int PortalRecursion { get; set; }
    public int CameraFOV { get; set; }

    public PlayerPrefModel()
    {
        Forward = PlayerConstants.ForwardDefault;
        Back = PlayerConstants.BackDefault;
        Left = PlayerConstants.LeftDefault;
        Right = PlayerConstants.RightDefault;
        Jump = PlayerConstants.JumpDefault;
        Crouch = PlayerConstants.CrouchDefault;
        ResetLevel = PlayerConstants.ResetLevelDefault;
        Portal1 = PlayerConstants.Portal1Default;
        Portal2 = PlayerConstants.Portal2Default;
        ResolutionWidth = OptionsPreferencesManager.defaultResolutionWidth;
        ResolutionHeight = OptionsPreferencesManager.defaultResolutionHeight;
        Volume = OptionsPreferencesManager.defaultVolume;
        Quality = OptionsPreferencesManager.defaultQuality;
        FullScreen = OptionsPreferencesManager.defaultIsFullScreen;
        Sensitivity = OptionsPreferencesManager.defaultSensitivity;
        PortalRecursion = OptionsPreferencesManager.defaultPortalRecursion;
        CameraFOV = OptionsPreferencesManager.defaultCameraFOV;
    }
}
