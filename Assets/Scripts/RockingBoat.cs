using UnityEngine;

public class RockingBoat : MonoBehaviour
{
    public float rotationAmplitude = 4f;
    public float rotationSpeed = 1f;

    private float initialRotationX;

    void Awake()
    {
        initialRotationX = transform.localEulerAngles.x;
    }

    void Update()
    {
        float newRotationX = initialRotationX + Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;

        transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
