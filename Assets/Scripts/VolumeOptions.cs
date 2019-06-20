using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOptions : MonoBehaviour
{
    // Const
    const string Volume = "Volume";

    // Config params
    [SerializeField] Sprite volumeOn;
    [SerializeField] Sprite volumeOff;

    [Header("SFX")]
    [SerializeField] AudioClip[] UISound;
    [SerializeField] [Range(0, 1)] float UISoundVolume = 0.7f;

    private void Start()
    {
        LoadSoundSettings();
    }

    private void MuteSound()
    {
        AudioListener.pause = true;
    }

    private void EnableSoundOnStart()
    {
        AudioListener.pause = false;
    }

    private void EnableSoundToggle()
    {
        MainMenuControl mainMenuControl = FindObjectOfType<MainMenuControl>();

        AudioClip clip = UISound[Random.Range(0, UISound.Length - 1)];
        AudioSource.PlayClipAtPoint(clip, mainMenuControl.transform.position, UISoundVolume);

        AudioListener.pause = false;
    }

    private void LoadSoundSettings()
    {
        if (PlayerPrefsController.GetVolume() == false && GetComponent<Image>() != null)
        {
            GetComponent<Image>().sprite = volumeOff;
            MuteSound();
        } else if (PlayerPrefsController.GetVolume() == true && GetComponent<Image>() != null)
        {
            GetComponent<Image>().sprite = volumeOn;
            EnableSoundOnStart();
        }
    }

    public void ToggleSound()
    {
        if (PlayerPrefsController.GetVolume() == false)
        {
            gameObject.GetComponent<Image>().sprite = volumeOn;
            PlayerPrefsController.SetVolume(true);
            EnableSoundToggle();
        }
        else
        {
            PlayerPrefsController.SetVolume(false);
            MuteSound();
            gameObject.GetComponent<Image>().sprite = volumeOff;
        }
    }
}
