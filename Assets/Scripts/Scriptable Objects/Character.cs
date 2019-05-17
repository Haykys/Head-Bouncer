using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField] int characterIndex = 0;
    [SerializeField] string characterName = "Default";
    [SerializeField] Sprite characterSprite;
    [SerializeField] RuntimeAnimatorController characterRuntimeAnimatorController;
    [SerializeField] int characterPointCost;
    [SerializeField] int playerHealth;

    public string CharacterName { get => characterName; set => characterName = value; }
    public Sprite CharacterSprite { get => characterSprite; set => characterSprite = value; }
    public RuntimeAnimatorController CharacterRuntimeAnimatorController { get => characterRuntimeAnimatorController; set => characterRuntimeAnimatorController = value; }
    public int CharacterPointCost { get => characterPointCost; set => characterPointCost = value; }
    public int CharacterIndex { get => characterIndex; set => characterIndex = value; }
    public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
}
