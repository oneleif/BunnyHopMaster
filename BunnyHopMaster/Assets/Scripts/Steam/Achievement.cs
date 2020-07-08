using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : ScriptableObject
{
    public Steamworks.Data.Stat stat;
    public bool state;
    public Sprite icon;
    public string title;
    public string description;
}
