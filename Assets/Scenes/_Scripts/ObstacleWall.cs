using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    [Header("Damage Settings")]
    public float damageAmount = 20f;
    public float damageCooldown = 1.0f;
    private float lastDamageTime = -999f;

    [Header("Audio")]
    public AudioClip blastSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check cooldown so player doesn't take damage too rapidly
            if (Time.time - lastDamageTime < damageCooldown) return;
            lastDamageTime = Time.time;

            // 1. Deal damage to the player
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // 2. Play blast sound effect
            if (blastSound != null)
            {
                AudioSource.PlayClipAtPoint(blastSound, transform.position);
            }

            // Wall is NOT destroyed - player passes through after taking damage
        }
    }
}
