using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuBehaviour : MonoBehaviour
{   
    public void PauseGame()
    {
        var go = GetPauseMenu();

        go.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        var go = GetPauseMenu();

        go.SetActive(false);
        Time.timeScale = 1f;
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
