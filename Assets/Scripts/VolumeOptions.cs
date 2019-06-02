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

    private void Start()
    {
        LoadSoundSettings();
    }

    private void MuteSound()
    {
        AudioListener.pause = true;
    }

    private void EnableSound()
    {
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
            EnableSound();
        }
    }

    public void ToggleSound()
    {
        if (PlayerPrefsController.GetVolume() == false)
        {
            gameObject.GetComponent<Image>().sprite = volumeOn;
            PlayerPrefsController.SetVolume(true);
            EnableSound();
        }
        else
        {
            PlayerPrefsController.SetVolume(false);
            MuteSound();
            gameObject.GetComponent<Image>().sprite = volumeOff;
        }
    }
}
