using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float healAmount = 20f;

    [Header("Audio")]
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Check if the player touched us
        if (other.CompareTag("Player"))
        {
            // 2. Find the HealthManager on the player and Heal
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            // 3. Play pickup sound effect
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // 4. Destroy the health pack so we can't pick it up twice
            Destroy(gameObject);
        }
    }

    // Optional: Destroy if it goes off screen (Cleanup)
    void Update()
    {
        if (transform.position.x < -15f) // Adjust based on your screen
        {
            Destroy(gameObject);
        }
    }
}