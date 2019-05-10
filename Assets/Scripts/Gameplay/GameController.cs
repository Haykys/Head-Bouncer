using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the main gameplay
/// </summary>
public class GameController : MonoBehaviour
{
    [Tooltip("A reference to the background we want to spawn")]
    [SerializeField] Transform background;
    [Tooltip("Where the first background should be placed at")]
    [SerializeField] Vector2 startPoint = new Vector2(0, 0);
    [Tooltip("How many tiles should we create in advance")]
    [Range(1, 15)]
    [SerializeField] int initSpawnNum = 10;

    /// <summary>
    /// Where the next background should be spawned at
    /// </summary>
    private Vector2 nextBackgroundLocation;

    /// <summary>
    /// How should the next background be rotated
    /// </summary>
    private Quaternion nextBackgroundRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Set our starting point
        nextBackgroundLocation = startPoint;
        nextBackgroundRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextBackground();
        }
    }

    /// <summary>
    /// Will spawn a background at a certain location and setup the next position
    /// </summary>
    public void SpawnNextBackground()
    {

        var newBackground = Instantiate(background, nextBackgroundLocation, nextBackgroundRotation);

        // Figure out where and at what rotation we should spawn
        // the next item
        var nextBackground = newBackground.Find("Next Spawn Point");
        nextBackgroundLocation = nextBackground.position;
        nextBackgroundRotation = nextBackground.rotation;
    }
}
