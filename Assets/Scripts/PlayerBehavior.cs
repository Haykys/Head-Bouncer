﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PlayerBehavior : MonoBehaviour
{
    // constants
    const string BouncingObject = "Bouncing Object";
    const string NonBouncingObject = "Non Bouncing Object";
    const string EmissionObject = "Emission Object";
    const string Floor = "Floor";

    // config params
    [SerializeField] float xOffset = 0.31f;
    [Header("Animation")]
    [SerializeField] float idleAnimationWaitTime = 4f;

    private bool hasMoved = false;
    private float touchTime;

    // cached ref
    GameSession gameSession;
    Animator myAnimator;
    CameraBehavior cameraBehaviour;
    EmitterSpawner emitterSpawner;
    PlayerHealth playerHealth;
    Rigidbody2D myRigidbody2D;


    public bool HasMoved { get => hasMoved; set => hasMoved = value; }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        gameSession = FindObjectOfType<GameSession>();
        cameraBehaviour = FindObjectOfType<CameraBehavior>();
        emitterSpawner = FindObjectOfType<EmitterSpawner>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;

        if (otherGameObject.layer == LayerMask.NameToLayer(NonBouncingObject))
        {
            playerHealth.DecreaseHealth(1);
            if (playerHealth.Health <= 0)
            {
                #region Game Over;
                GameObject[] bouncingObjects = GameObject.FindGameObjectsWithTag(BouncingObject);

                for (int i = 0; i < bouncingObjects.Length; i++)
                {
                    bouncingObjects[i].SetActive(false);
                }

                gameObject.SetActive(false);
                Destroy(otherGameObject);
                gameSession.ResetGame();
                #endregion
            }

        }
    }

    #region Jump
    private void Jump()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                touchTime = Time.time;
            }

            // User has tapped
            if (touch.phase == TouchPhase.Ended)
            {
                var isTouchingFloor = GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask(Floor));

                if (Time.time - touchTime <= 0.5f && isTouchingFloor)
                {
                    Vector2 jumpVelocityToAdd = new Vector2(0f, 8f);
                    myRigidbody2D.AddForce(jumpVelocityToAdd, ForceMode2D.Impulse);
                }
            }
        }
    }
    #endregion

    #region Player Movement
    private void PlayerMovement()
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);

        if (Input.touchCount > 0 && FindObjectOfType<BoxCollider2D>())
        {
            Touch touch = Input.touches[0];

            if (touch.deltaPosition.x > 1)
            {
                myAnimator.SetBool("isWalking", true);
                transform.localScale = new Vector2(-1f, 1f);
            } else if (touch.deltaPosition.x < 0)
            {
                myAnimator.SetBool("isWalking", true);
                transform.localScale = new Vector2(1f, 1f);
            }

            // Because of the game being pause when it starts up
            FindObjectOfType<GameOverMenuBehavior>().SetPauseMenu(false);

            if (!HasMoved && GameObject.FindGameObjectWithTag("Usher NPC") || GameObject.FindGameObjectWithTag("Usher Text"))
            {
                HasMoved = true;
                cameraBehaviour.CameraMovementSpeed = 1f;
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("Usher NPC").Length; i++)
                {
                    Destroy(GameObject.FindGameObjectsWithTag("Usher NPC")[i]);
                }
                Destroy(GameObject.FindGameObjectWithTag("Usher Text"));
            }

            float screenPosX = Camera.main.transform.position.x;

            float screenHalf = Camera.main.orthographicSize * Screen.width / Screen.height;

            float leftSideOfScreen = Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width / Screen.height;

            float rightSideOfScreen = Camera.main.transform.position.x + Camera.main.orthographicSize * Screen.width / Screen.height;

            float touchPosInUnits = ((rightSideOfScreen - leftSideOfScreen) * (touch.position.x / Screen.width)) + leftSideOfScreen;

            if (gameSession.IsAutoplayEnabled() && GameObject.FindGameObjectWithTag(BouncingObject))
            {
                if(GameObject.FindGameObjectsWithTag(BouncingObject).Length > 1)
                {
                    GameObject[] bouncingObjects = GameObject.FindGameObjectsWithTag(BouncingObject);
                    bouncingObjects = bouncingObjects.OrderBy(bouncingObject => bouncingObject.transform.position.y).ToArray();

                    // Set player position the the bouncing object with lowest transform.position.y value
                    playerPos.x = bouncingObjects[0].transform.position.x;

                } else
                {
                    playerPos.x = GameObject.FindGameObjectWithTag(BouncingObject).transform.position.x;
                }
            } else
            {
                playerPos.x = Mathf.Clamp(touchPosInUnits, leftSideOfScreen + xOffset, rightSideOfScreen - xOffset);
            }
            transform.position = playerPos;

        }
    }
    #endregion

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
