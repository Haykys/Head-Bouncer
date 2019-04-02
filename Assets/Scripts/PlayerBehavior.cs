using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehavior : MonoBehaviour
{
    // constants
    string BouncingObject = "Bouncing Object";
    string EmissionObject = "Emission Object";

    // config params
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 5f;
    [SerializeField] float screenWidthInUnits = 6f;
    [Header("Animation")]
    [SerializeField] float idleAnimationWaitTime = 4f;

    private float playerOffset = 3.2f;
    private bool hasMoved = false;

    // cached ref
    GameSession gameSession;
    Animator myAnimator;
    CameraBehavior cameraBehaviour;
    EmitterSpawner emitterSpawner;

    public bool HasMoved { get => hasMoved; set => hasMoved = value; }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        gameSession = FindObjectOfType<GameSession>();
        cameraBehaviour = FindObjectOfType<CameraBehavior>();
        emitterSpawner = FindObjectOfType<EmitterSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        playerPos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = playerPos;

#elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            // Because of the game being pause when it starts up
            FindObjectOfType<GameOverMenuBehavior>().SetPauseMenu(false);

            if (GameObject.FindGameObjectWithTag("Usher NPC") || GameObject.FindGameObjectWithTag("Usher Text")) { }
            {
                HasMoved = true;
                cameraBehaviour.CameraMovementSpeed = 1f;
                Destroy(GameObject.FindGameObjectWithTag("Usher NPC"));
                Destroy(GameObject.FindGameObjectWithTag("Usher Text"));
            }


            Touch touch = Input.touches[0];

            float screenPosX = Camera.main.transform.position.x;

            float touchPosInUnits = touch.position.x / Screen.width * screenWidthInUnits;

            playerPos.x = Mathf.Clamp(touchPosInUnits + screenPosX - playerOffset, screenPosX - minX, screenPosX + maxX);
            transform.position = playerPos;

        }
#endif

    }

    #region PlayerAnimation

    private void setPlayerIdleAnimationTrue()
    {
        myAnimator.SetBool("playIdleBlueShirtDude", true);
    }

    public void WaitTillNextIdleAnimation()
    {
        myAnimator.SetBool("playIdleBlueShirtDude", false);
        Invoke("setPlayerIdleAnimationTrue", idleAnimationWaitTime);
    }

    #endregion
}
