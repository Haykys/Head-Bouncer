using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehavior : MonoBehaviour
{
    // constants
    string BouncingObject = "Bouncing Object";

    // config params
    [SerializeField] float minX = -3f;
    [SerializeField] float maxX = 0f;
    [SerializeField] float screenWidthInUnits = 6f;

    // cached ref
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
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

            float touchPosInUnits = touch.position.x / Screen.width * screenWidthInUnits;
            playerPos.x = Mathf.Clamp(touchPosInUnits, Camera.main.transform.position.x + minX + touchPosInUnits, Camera.main.transform.position.x);
            transform.position = playerPos;

        }
#endif

    }
}
