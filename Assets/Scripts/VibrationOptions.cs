using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationOptions : MonoBehaviour
{
    // Const
    const string Vibration = "Vibration";

    // Config params
    [SerializeField] Sprite vibrationOn;
    [SerializeField] Sprite vibrationOff;

    private void Start()
    {
        LoadVibrationSettings();
    }

    private void LoadVibrationSettings()
    {
        if (PlayerPrefsController.GetVibration() == false && GetComponent<Image>() != null)
        {
            GetComponent<Image>().sprite = vibrationOff;
        }
        else if (PlayerPrefsController.GetVibration() == true && GetComponent<Image>() != null)
        {
            GetComponent<Image>().sprite = vibrationOn;
        }
    }

    public void ToggleVibration()
    {
        if (PlayerPrefsController.GetVibration() == false)
        {
            Handheld.Vibrate();
            gameObject.GetComponent<Image>().sprite = vibrationOn;
            PlayerPrefsController.SetVibration(true);
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = vibrationOff;
            PlayerPrefsController.SetVibration(false);
        }
    }
}
