using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncingSpree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisplayBouncingSpree();
    }

    private void DisplayBouncingSpree()
    {
        if (PlayerPrefsController.GetBestBouncingSpree() > 0)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefsController.GetBestBouncingSpree().ToString();
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        }
    }
}
