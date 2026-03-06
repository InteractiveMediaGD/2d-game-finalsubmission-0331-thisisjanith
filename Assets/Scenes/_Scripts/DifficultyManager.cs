using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    // Static so other scripts (Enemies) can read it easily
    public static float globalSpeed = 1f;

    [Header("Settings")]
    public float speedIncreaseRate = 0.05f; // How much faster per second
    public float maxSpeed = 3f;             // Cap the speed so it's not impossible [cite: 54]

    void Start()
    {
        // Reset speed when game restarts
        globalSpeed = 1f;
    }

    void Update()
    {
        // Slowly increase speed over time
        globalSpeed += speedIncreaseRate * Time.deltaTime;

        // Cap the speed
        if (globalSpeed > maxSpeed)
        {
            globalSpeed = maxSpeed;
        }

        // Optional: Debug to see speed in console
        // Debug.Log("Current Speed Multiplier: " + globalSpeed);
    }
}