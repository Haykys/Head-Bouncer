
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuBehavior : MonoBehaviour
{
    // State
    private static bool paused;

    //  Constant
    const string BouncingObject = "Bouncing Object";
    const string Player = "Player";

    // cached ref
    [Tooltip("Reference to the pause menu object to tun on/off")]
    [SerializeField] GameObject gameOverMenu;
    [Tooltip("Reference to the player")]

    GameObject player;
    PauseMenuBehaviour pauseMenuBehaviour;

    public static bool Paused { get => paused; set => paused = value; }

    private void Start()
    {
        pauseMenuBehaviour = FindObjectOfType<PauseMenuBehaviour>();

        player = GameObject.FindGameObjectWithTag(Player);
    }

    /// <summary>
    /// Hadles resetting the game if needed
    /// </summary>
    public void Continue()
    {
        GameObject[] bouncingObjects = GameObject.FindGameObjectsWithTag(BouncingObject);

        for (int i = 0; i < bouncingObjects.Length; i++)
        {
            Destroy(bouncingObjects[i]);
        }

        player.GetComponent<Renderer>().enabled = true;

        pauseMenuBehaviour.ShowPauseButton();
        SetPauseMenu(false);
    }

    /// <summary>
    /// Reloads our current level, effectively "restarting" the game
    /// </summary>
    public void Restart()
    {
        SetPauseMenu(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Will turn our pause menu on or off
    /// </summary>
    /// <param name="isPaused"></param>
    public void SetPauseMenu(bool isPaused)
    {
        Paused = isPaused;

        Debug.Log("Game Paused " + Paused);

        // If the game is paused, timeScale is 0, otherwise 1
        Time.timeScale = (Paused) ? 0 : 1;

    }
}
