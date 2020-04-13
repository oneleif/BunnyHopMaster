﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerUI : MonoBehaviour
{
    public bool isPaused;

    [SerializeField]
    private GameObject inGameUI;

    [SerializeField]
    private PauseMenu pauseMenu;

    [SerializeField]
    private WinMenu winMenu;

    public Image crossHair;

    private void Start()
    {
        inGameUI.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        winMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Don't let the player pause the game if they are in the win menu
        // This would let the player unpause and play during the win menu
        if (GameManager.Instance.didWinCurrentLevel)
        {
            return;
        }

        if (Input.GetKeyDown(HotKeyManager.Instance.GetKeyFor(PlayerConstants.PauseMenu)))
        {
            if (isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(HotKeyManager.Instance.GetKeyFor(PlayerConstants.NextLevel)))
        {
            winMenu.NextLevel();
        }
    }

    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void UnPause()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        inGameUI.SetActive(true);
    }

    public void ShowWinScreen()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        inGameUI.SetActive(false);
        winMenu.gameObject.SetActive(true);

        winMenu.levelText.text = GameManager.GetCurrentLevel().levelName;
        winMenu.completionTimeText.text = "Completion time: " + GetTimeString(GameManager.Instance.currentCompletionTime);

        TimeSpan time = TimeSpan.FromSeconds(GameManager.GetCurrentLevel().completionTime);
        winMenu.bestTimeText.text = "Best time: " + time.ToString(PlayerConstants.levelCompletionTimeFormat);
    }

    private string GetTimeString(float completionTime)
    {
        TimeSpan time = TimeSpan.FromSeconds(completionTime);
        return time.ToString(PlayerConstants.levelCompletionTimeFormat);
    }
}