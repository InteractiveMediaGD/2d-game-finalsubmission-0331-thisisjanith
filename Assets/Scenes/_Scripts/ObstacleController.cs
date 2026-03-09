using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 4f;

    [Header("Damage Settings")]
    public float damageAmount = 20f;
    public float damageCooldown = 1.0f;
    private float lastDamageTime = -999f;

    [Header("Audio")]
    public AudioClip blastSound;

    void Update()
    {
        // Move Left (speed scales with difficulty)
        float currentSpeed = moveSpeed * DifficultyManager.globalSpeed;
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime, Space.World);

        // Destroy when off-screen
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    // Handle collision with the Player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check cooldown
            if (Time.time - lastDamageTime < damageCooldown) return;
            lastDamageTime = Time.time;

            // 1. Deal damage to the player
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // 2. Play blast sound
            if (blastSound != null)
            {
                AudioSource.PlayClipAtPoint(blastSound, transform.position);
            }
        }
    }
}
