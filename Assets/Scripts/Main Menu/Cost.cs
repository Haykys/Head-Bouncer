using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{

    [SerializeField] string parentCharacterName = "Default";

    public void HidePointCost(string[] ownedCharacters)
    {
        foreach(string ownedCharacter in ownedCharacters)
        {
            if (parentCharacterName == ownedCharacter)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
