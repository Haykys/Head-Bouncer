using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisplayPoints();
    }

    private void DisplayPoints()
    {
        if (PlayerPrefsController.GetPoints() > 0)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefsController.GetPoints().ToString();
        } else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        }
    }

}
