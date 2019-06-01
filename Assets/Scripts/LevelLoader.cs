using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // const
    string MainMenu = "Main Menu";

    //config params
    [Header("SFX")]
    [SerializeField] AudioClip[] UISound;
    [SerializeField] [Range(0, 1)] float UISoundVolume = 0.7f;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        AudioClip clip = UISound[Random.Range(0, UISound.Length - 1)];
        AudioSource.PlayClipAtPoint(clip, transform.position, UISoundVolume);

        Initiate.Fade("Game Scene", Color.white, 1f);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
