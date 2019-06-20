 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuBehaviour : MonoBehaviour
{
    private bool gameIsPaused = false;

    public bool GameIsPaused { get => gameIsPaused; set => gameIsPaused = value; }

    public void PauseGame()
    {
        GameIsPaused = true;
        HidePauseButton();

        var go = GetPauseMenu();

        go.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        GameIsPaused = false;
        ShowPauseButton();

        var go = GetPauseMenu();

        go.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HidePauseButton()
    {
        gameObject.SetActive(false);
    }

    public void ShowPauseButton()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Show Pauuse Menu
    /// </summary>
    /// <returns></returns>
    public GameObject GetPauseMenu()
    {
        return GameObject.Find("Game Canvas").transform.Find("Pause Menu").gameObject;
    }
}
