using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    private float cameraMovementSpeed = 0f;

    public float CameraMovementSpeed { get => cameraMovementSpeed; set => cameraMovementSpeed = value; }

    // Transform of the GameObject you want to shake
    private new Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.03f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 12.0f;

    // The position to return to after shake
    Vector3 returnPosition;

    // Overall shake of the screen
    Vector3 shakeAmount;

    // Shake has started
    private bool isShaking = false;
    private float cameraPositionY = 0f;

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void Start()
    {
        cameraPositionY = transform.position.y;
    }

    public void TriggerShake()
    {
        isShaking = true;
        shakeDuration = 1.0f;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * CameraMovementSpeed);

        if (isShaking)
        {
            if (shakeDuration > 0)
            {
                shakeAmount = Random.insideUnitSphere * shakeMagnitude;

                transform.position = transform.position + shakeAmount;
                returnPosition = transform.position - shakeAmount;

                shakeDuration -= Time.deltaTime * dampingSpeed;
            }
            else
            {
                isShaking = false;
                shakeDuration = 0f;
                transform.position = new Vector3(returnPosition.x, cameraPositionY, returnPosition.z);
            }
        }
    }
}
