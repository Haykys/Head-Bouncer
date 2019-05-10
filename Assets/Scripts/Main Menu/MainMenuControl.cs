using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public class MainMenuControl : MonoBehaviour
{
    // constants
    const string CharacterSelection = "Character Selection";
    const string Player = "Player";

    // config params
    [SerializeField] Character[] characters;
    private int characterChoice;

    // cached ref
    GameObject characterSelection;
    GlobalManager globalManager;
    GameObject player;
    ModalPanel modalPanel;
    Cost[] costs;

    private void Start()
    {
        // PlayerPrefs.DeleteAll();

        string[] ownedCharacters = PlayerPrefsController.GetCharacters();
        costs = FindObjectsOfType<Cost>();

        foreach (Cost cost in costs)
        {
            cost.HidePointCost(ownedCharacters);
        }

        characterSelection = GameObject.FindGameObjectWithTag(CharacterSelection);
        globalManager = FindObjectOfType<GlobalManager>();
        player = GameObject.FindGameObjectWithTag(Player);
        modalPanel = FindObjectOfType<ModalPanel>();

        SetCharacterOnStart(PlayerPrefsController.GetCharacter());
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

    private void SetCharacterOnStart(int characterChoice)
    {
        if (PlayerPrefsController.GetCharacters().Length == 0)
        {
            PlayerPrefsController.SetCharacter(0);
            PlayerPrefsController.SetCharacters("dudeWithBlueShirt");
            BuyOrSelectCharacter(0);
        } else
        {
            BuyOrSelectCharacter(characterChoice);
        }
    }

    public void OnCharacterSelect(int characterChoice)
    {
        this.characterChoice = characterChoice;

        var characterButtons = FindObjectsOfType<CharacterSelectionButton>();
        Character selectedCharacter = characters[characterChoice];
        string[] ownedCharacters = PlayerPrefsController.GetCharacters();

        foreach (string ownedCharacter in ownedCharacters)
        {
            if (selectedCharacter.CharacterName == ownedCharacter)
            {
                BuyOrSelectCharacter(selectedCharacter.CharacterIndex);
                return;
            }
        }

        if (PlayerPrefsController.GetPoints() >= selectedCharacter.CharacterPointCost)
        {
            modalPanel.ShowPanelSuccess();
        } else
        {
            modalPanel.ShowPanelFail();
        }
    }

    public void ModalYesFunction()
    {
        BuyOrSelectCharacter(characterChoice);
        modalPanel.ClosePanelSuccess();
    }

    public void ModalNoFunction()
    {
        modalPanel.ClosePanelSuccess();
    }

    public void ModalOkFunction()
    {
        modalPanel.ClosePanelFail();
    }

    private void BuyOrSelectCharacter(int characterChoice)
    {
        var characterButtons = FindObjectsOfType<CharacterSelectionButton>();
        Character selectedCharacter = characters[characterChoice];
        string[] ownedCharacters = PlayerPrefsController.GetCharacters();

        if(ownedCharacters.Contains(selectedCharacter.CharacterName) == false)
        {
            PlayerPrefsController.SetCharacters(selectedCharacter.CharacterName);
            string[] updatedOwnedCharacters = PlayerPrefsController.GetCharacters();
            foreach (Cost cost in costs)
            {
                cost.HidePointCost(updatedOwnedCharacters);
            }
        }

        PlayerPrefsController.SetCharacter(characterChoice);

        foreach (CharacterSelectionButton characterButton in characterButtons)
        {
            if (characterButton.CharacterIndex == characterChoice)
            {
                characterButton.GetComponent<Toggle>().interactable = false;
                globalManager.CharacterSprite = selectedCharacter.CharacterSprite;
                globalManager.CharacterRuntimeAnimatorController = selectedCharacter.CharacterRuntimeAnimatorController;
                globalManager.SetCharacter(player);
            }
            else
            {
                characterButton.GetComponent<Toggle>().interactable = true;
            }
        }
    }
}
