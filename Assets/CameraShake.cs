using UnityEngine;

public class CameraShake: MonoBehaviour
    {
    // Intensity of the shake
    public float shakeIntensity = 0.1f;

    // Duration of the shake
    public float shakeDuration = 0.5f;

    private Vector3 originalPosition;
    private float shakeTimer;

    void Start ( )
        {
        // Save the original position of the camera
        originalPosition = transform.position;
        }

    void Update ( )
        {
        if (shakeTimer > 0)
            {
            // Shake the camera
            transform.position = originalPosition + Random.insideUnitSphere * shakeIntensity;

            // Decrease the shake timer
            shakeTimer -= Time.deltaTime;
            }
        else
            {
            // Reset the camera position after the shake duration
            transform.position = originalPosition;
            }
        }

    // Call this method to start the camera shake
    public void StartShake (float shakeDuration , float ShakePower )
        {
        shakeIntensity = ShakePower;
        shakeTimer = shakeDuration;
        }
    }
