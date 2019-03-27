﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehavior : MonoBehaviour
{
    // constants
    string BouncingObject = "Bouncing Object";

    // config params
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 5f;
    [SerializeField] float screenWidthInUnits = 6f;
    [Header("Animation")]
    [SerializeField] float idleAnimationWaitTime = 4f;

    private float playerOffset = 3.2f;

    // cached ref
    GameSession gameSession;
    Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        gameSession = FindObjectOfType<GameSession>();
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
