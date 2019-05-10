using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    private float cameraMovementSpeed = 0f;

    public float CameraMovementSpeed { get => cameraMovementSpeed; set => cameraMovementSpeed = value; }

    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * CameraMovementSpeed);
        
    }
}
