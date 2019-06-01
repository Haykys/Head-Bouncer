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

    [Header("SFX")]
    [SerializeField] AudioClip[] UISound;
    [SerializeField] [Range(0, 1)] float UISoundVolume = 0.7f;

    // cached ref
    GameObject characterSelection;
    GlobalManager globalManager;
    GameObject player;
    ModalPanel modalPanel;
    Cost[] costs;
    Points points;

    private void Start()
    {
        // PlayerPrefs.DeleteAll();

        string[] ownedCharacters = PlayerPrefsController.GetCharacters();
        costs = FindObjectsOfType<Cost>();

        foreach (Cost cost in costs)
        {
            cost.HidePointCost(ownedCharacters);
        }

        globalManager = FindObjectOfType<GlobalManager>();
        modalPanel = FindObjectOfType<ModalPanel>();
        player = GameObject.FindGameObjectWithTag(Player);
        characterSelection = GameObject.FindGameObjectWithTag(CharacterSelection);
        points = FindObjectOfType<Points>();

        SetCharacterOnStart(PlayerPrefsController.GetCharacter());
    }

    /// <summary>
    /// Set character selection modal to active
    /// </summary>
    public void DisplayCharacterSelect()
    {
        AudioClip clip = UISound[Random.Range(0, UISound.Length - 1)];
        AudioSource.PlayClipAtPoint(clip, transform.position, UISoundVolume);

        characterSelection.GetComponent<CanvasGroup>().alpha = 1;
        characterSelection.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    /// <summary>
    /// Hide character selection modal
    /// </summary>
    public void CloseCharacterSelect()
    {
        AudioClip clip = UISound[Random.Range(0, UISound.Length - 1)];
        AudioSource.PlayClipAtPoint(clip, transform.position, UISoundVolume);

        characterSelection.GetComponent<CanvasGroup>().alpha = 0;
        characterSelection.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /// <summary>
    /// When game start set last active character as selected
    /// </summary>
    /// <param name="characterChoice">index of the character</param>
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

    /// <summary>
    /// Either select the character or open modal
    /// </summary>
    /// <param name="characterChoice">Index of the selected character</param>
    public void OnCharacterSelect(int characterChoice)
    {
        Debug.Log("CALLING");

        this.characterChoice = characterChoice;

        CharacterSelectionButton[] characterButtons = FindObjectsOfType<CharacterSelectionButton>();
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
            FixIsOnBug(characterButtons);
        }
        else
        {
            modalPanel.ShowPanelFail();
            FixIsOnBug(characterButtons);
        }
    }

    /// <summary>
    /// Fix when selecting character that is not owned and then selecting owned character pop up
    /// </summary>
    /// <param name="characterButtons">Character buttons (toggles)</param>
    private static void FixIsOnBug(CharacterSelectionButton[] characterButtons)
    {
        foreach (CharacterSelectionButton characterButton in characterButtons)
        {
            characterButton.GetComponent<Toggle>().isOn = false;
        }
    }

    public void ModalYesFunction()
    {
        AudioClip clip = UISound[Random.Range(0, UISound.Length - 1)];
        AudioSource.PlayClipAtPoint(clip, transform.position, UISoundVolume);

        BuyOrSelectCharacter(characterChoice);
        modalPanel.ClosePanelSuccess();
    }

    public void ModalNoFunction()
    {
        AudioClip clip = UISound[Random.Range(0, UISound.Length - 1)];
        AudioSource.PlayClipAtPoint(clip, transform.position, UISoundVolume);

        modalPanel.ClosePanelSuccess();
    }

    public void ModalOkFunction()
    {
        AudioClip clip = UISound[Random.Range(0, UISound.Length - 1)];
        AudioSource.PlayClipAtPoint(clip, transform.position, UISoundVolume);

        modalPanel.ClosePanelFail();
    }

    /// <summary>
    /// If character isn't inside of playerPrefs buy it otherwise select
    /// </summary>
    /// <param name="characterChoice">Index of the clicked character</param>
    private void BuyOrSelectCharacter(int characterChoice)
    {
        CharacterSelectionButton[] characterButtons = FindObjectsOfType<CharacterSelectionButton>();
        Character selectedCharacter = characters[characterChoice];
        string[] ownedCharacters = PlayerPrefsController.GetCharacters();

        if(ownedCharacters.Contains(selectedCharacter.CharacterName) == false)
        {
            int newPointsTotal = PlayerPrefsController.GetPoints() - selectedCharacter.CharacterPointCost;
            PlayerPrefsController.SetPoints(newPointsTotal);
            points.DisplayPoints();

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
                globalManager.PlayerHealth = selectedCharacter.PlayerHealth;
                globalManager.SetCharacter(player);
            }
            else
            {
                characterButton.GetComponent<Toggle>().interactable = true;
            }
        }
    }
}
