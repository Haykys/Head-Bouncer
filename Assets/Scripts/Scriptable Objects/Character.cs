using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField] string characterName = "Default";
    [SerializeField] Sprite characterSprite;
    [SerializeField] RuntimeAnimatorController characterRuntimeAnimatorController;

    public string CharacterName { get => characterName; set => characterName = value; }
    public Sprite CharacterSprite { get => characterSprite; set => characterSprite = value; }
    public RuntimeAnimatorController CharacterRuntimeAnimatorController { get => characterRuntimeAnimatorController; set => characterRuntimeAnimatorController = value; }
}
