using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisplayLastScore();
    }

    private void DisplayLastScore()
    {
        if (PlayerPrefsController.GetBestScore() > 0)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefsController.GetLastScore().ToString();
        }
    }
}
