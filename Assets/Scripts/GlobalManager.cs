using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    private static GlobalManager instance;

    // cached ref
    // Serilized only for testing
    [SerializeField] private Sprite characterSprite;
    [SerializeField]  private RuntimeAnimatorController characterRuntimeAnimatorController;

    public Sprite CharacterSprite { get => characterSprite; set => characterSprite = value; }
    public RuntimeAnimatorController CharacterRuntimeAnimatorController { get => characterRuntimeAnimatorController; set => characterRuntimeAnimatorController = value; }

    public static GlobalManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GlobalManager>();
            }

            return instance;
        }
    }

    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #region Set Character
    public void SetCharacter(GameObject player)
    {
        if (CharacterSprite && CharacterRuntimeAnimatorController && player)
        {
            player.GetComponent<SpriteRenderer>().sprite = CharacterSprite;

            if (player.GetComponent<PlayerBehavior>() && !player.GetComponent<Animator>())
            {
                player.AddComponent<Animator>();
            }

            if (player.GetComponent<PlayerBehavior>() && player.GetComponent<Animator>())
            {
                player.GetComponent<Animator>().runtimeAnimatorController = CharacterRuntimeAnimatorController;
            }
        }
    }

    #endregion
}
