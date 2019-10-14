﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    public Text sensitivityValue;

    public AudioMixer audioMixer;
    public Text volumeValue;

    public Dropdown resolutionDropdown;

    public Dropdown graphicsQualityDropdown;
    public Toggle fullScreenToggle;

    Resolution[] resolutions;

    private void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        graphicsQualityDropdown.value = QualitySettings.GetQualityLevel();
        graphicsQualityDropdown.RefreshShownValue();

        fullScreenToggle.isOn = Screen.fullScreen;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);
        volumeValue.text = volume + "%";
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
    }

    public void SetSensitivity(float sensitivity)
    {
        PlayerMovement playerMovement = GetComponentInParent<PlayerMovement>();
        playerMovement.xMouseSensitivity = sensitivity;
        playerMovement.yMouseSensitivity = sensitivity;

        sensitivityValue.text = sensitivity.ToString();
    }
}
