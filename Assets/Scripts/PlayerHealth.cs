using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // config params
    [Header("Player Params")]
    [SerializeField] int playerHealth = 3;

    public int Health { get => playerHealth; set => playerHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        DisplayHealth();
    }

    /// <summary>
    /// Displays the heath to the player
    /// </summary>
    public void DisplayHealth()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = Health.ToString();
    }

    public void DecreaseHealth(int amount)
    {
        Health -= amount;
        DisplayHealth();
    }

    public void IncreaseHealth(int amount)
    {
        Health -= amount;
        DisplayHealth();
    }
}
