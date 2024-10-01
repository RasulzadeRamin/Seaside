using UnityEngine;

public class RockingBoat : MonoBehaviour
{
    public float rotationAmplitude = 4f; // Maximum rotation angle (4 degrees)
    public float rotationSpeed = 1f; // Speed of the rocking motion

    private float initialRotationX; // To store the initial X rotation of the boat

    void Awake()
    {
        // Store the initial local X rotation of the boat
        initialRotationX = transform.localEulerAngles.x;
    }

    void Update()
    {
        // Calculate the new X rotation using a sinusoidal function
        float newRotationX = initialRotationX + Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;

        // Apply the new X rotation while keeping other rotations unaffected
        transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
