using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // const
    string MainMenu = "Main Menu";

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        Initiate.Fade("Game Scene", Color.white, 1f);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
