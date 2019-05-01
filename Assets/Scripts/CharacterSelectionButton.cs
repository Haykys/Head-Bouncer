using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionButton : MonoBehaviour
{
    // constants
    [SerializeField] int characterIndex = 0;
    [SerializeField] GameObject characterButton;

    public int CharacterIndex { get => characterIndex; set => characterIndex = value; }
    public GameObject CharacterButton { get => characterButton; set => characterButton = value; }
}
