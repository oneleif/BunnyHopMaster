using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefData
{
    // Options
    public int ResolutionWidth { get; set; }
    public int ResolutionHeight { get; set; }
    public int Volume { get; set; }
    public int Quality { get; set; }
    public int IsFullScreen { get; set; }
    public float Sensitivity { get; set; }
    public int PortalRecursion { get; set; }
    public int CameraFOV { get; set; }


    // Hotkeys
    public string Forward { get; set; }
    public string Back { get; set; }
    public string Left { get; set; }
    public string Right { get; set; }
    public string Jump { get; set; }
    public string Crouch { get; set; }
    public string ResetLevel { get; set; }
    public string Portal1 { get; set; }
    public string Portal2 { get; set; }
}
