using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using TMPro;

//  This script will be updated in Part 2 of this 2 part series.
public class ModalPanel : MonoBehaviour
{
    [SerializeField] GameObject modalPanelSuccess;
    [SerializeField] GameObject modalPanelFail;

    /// <summary>
    /// Show Modal Panel
    /// </summary>
    public void ShowPanelSuccess()
    {
        modalPanelSuccess.SetActive(true);
    }

    public void ClosePanelSuccess()
    {
        modalPanelSuccess.SetActive(false);
    }

    public void ShowPanelFail()
    {
        modalPanelFail.SetActive(true);
    }

    public void ClosePanelFail()
    {
        modalPanelFail.SetActive(false);
    }
}