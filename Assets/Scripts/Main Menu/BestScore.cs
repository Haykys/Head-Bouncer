using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisplayBestScore();
    }

    private void DisplayBestScore()
    {
        if(PlayerPrefsController.GetBestScore() > 0)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefsController.GetBestScore().ToString();
        } else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        }
    }

}
