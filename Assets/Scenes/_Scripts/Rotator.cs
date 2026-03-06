using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Settings")]
    public float minSpin = 100f;
    public float maxSpin = 300f;

    private float currentSpeed;

    void Start()
    {
        // Pick a random speed and direction (positive or negative)
        // This makes every asteroid spin differently!
        currentSpeed = Random.Range(minSpin, maxSpin) * (Random.value > 0.5f ? 1 : -1);
    }

    void Update()
    {
        // Rotate around the Z axis (spinning like a wheel)
        transform.Rotate(0, 0, currentSpeed * Time.deltaTime);
    }
}