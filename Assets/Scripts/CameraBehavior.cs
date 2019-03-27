using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    [SerializeField] float movementSpeed = 1f;

    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movementSpeed);
    }
}
