using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscOptions : MonoBehaviour
{
    private Toggle showGhost;
    public GameObject togglePrefab;
    public Transform scrollViewContent;

    void Start()
    {
        InitializeShowGhost();
    }

    public void SetDefaults()
    {
        OptionsPreferencesManager.SetShowGhost(OptionsPreferencesManager.defaultshowGhost != 0);
        showGhost.isOn = (OptionsPreferencesManager.defaultshowGhost != 0);
    }

    public void SetShowGhost(bool newSetting)
    {
        OptionsPreferencesManager.SetShowGhost(newSetting);
    }

    public void InitializeShowGhost()
    {
        if (showGhost == null)
        {
            GameObject newToggle = Instantiate(togglePrefab, scrollViewContent);
            showGhost = newToggle.GetComponentInChildren<Toggle>();
            newToggle.GetComponentInChildren<Text>().text = "Show Ghost Runner";
        }
        showGhost.isOn = OptionsPreferencesManager.GetShowGhost();
        showGhost.onValueChanged.AddListener(delegate { SetShowGhost(showGhost.isOn); });
    }
    
}
