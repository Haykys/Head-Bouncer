using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        var characterButtons = FindObjectsOfType<CharacterSelectionButton>();
        Character selectedCharacter = characters[characterChoice];

        foreach (CharacterSelectionButton characterButton in characterButtons)
        {
            if (characterButton.CharacterIndex == characterChoice)
            {
                characterButton.GetComponent<Toggle>().Select();
                characterButton.GetComponent<Toggle>().interactable = false;
                globalManager.CharacterSprite = selectedCharacter.CharacterSprite;
                globalManager.CharacterRuntimeAnimatorController = selectedCharacter.CharacterRuntimeAnimatorController;
                globalManager.SetCharacter(player);
            } else
            {
                characterButton.GetComponent<Toggle>().interactable = true;
            }
        }
    }
}
