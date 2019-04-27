using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    // constants
    const string CharacterSelection = "Character Selection";
    const string Player = "Player";

    // config params
    [SerializeField] Character[] characters;

    // cached ref
    GameObject characterSelection;
    GlobalManager globalManager;
    GameObject player;

    private void Start()
    {
        characterSelection = GameObject.FindGameObjectWithTag(CharacterSelection);
        globalManager = FindObjectOfType<GlobalManager>();
        player = GameObject.FindGameObjectWithTag(Player);

        OnCharacterSelect(0);
    }

    public void DisplayCharacterSelect()
    {
        characterSelection.GetComponent<CanvasGroup>().interactable = true;
        characterSelection.GetComponent<CanvasGroup>().alpha = 1;
        characterSelection.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void CloseCharacterSelect()
    {
        characterSelection.GetComponent<CanvasGroup>().interactable = false;
        characterSelection.GetComponent<CanvasGroup>().alpha = 0;
        characterSelection.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnCharacterSelect(int characterChoice)
    {
        Character selectedCharacter = characters[characterChoice];
        globalManager.CharacterSprite = selectedCharacter.CharacterSprite;
        globalManager.CharacterRuntimeAnimatorController = selectedCharacter.CharacterRuntimeAnimatorController;
        globalManager.SetCharacter(player);
    }
}
