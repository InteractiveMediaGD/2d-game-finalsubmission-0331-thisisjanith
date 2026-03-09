using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;

    [Header("Audio")]
    public AudioClip blastSound;

    void Start()
    {
        // Destroy self automatically after 2 seconds to clean up memory
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move to the Right (Horizontal Side Scroller mode)
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Logic for hitting an Enemy
        if (other.CompareTag("Enemy"))
        {
            // 1. Add Score
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(50);
            }

            // --- NEW: Small Screen Shake ---
            // Small shake (0.1 intensity) for 0.1 seconds
            if (CameraShake.instance != null)
            {
                CameraShake.instance.Shake(0.1f, 0.1f);
            }
            // -------------------------------

            // 2. Play blast sound effect
            if (blastSound != null)
            {
                AudioSource.PlayClipAtPoint(blastSound, transform.position);
            }

            // 3. Destroy the Enemy
            Destroy(other.gameObject);

            // 4. Destroy the Projectile (Bullet)
            Destroy(gameObject);
        }
        // Logic for hitting walls (Cleanup)
        // We check tags so we don't accidentally destroy the bullet when spawning inside the player
        // Also skip Obstacle (corridor walls) so bullets can fly past them
        else if (!other.CompareTag("Player") && !other.CompareTag("ScoreTrigger") && !other.CompareTag("HealthPack") && !other.CompareTag("Obstacle"))
        {
            // DEBUG: Find out what is destroying the bullet
            Debug.Log("Bullet destroyed by: " + other.gameObject.name + " (Tag: " + other.tag + ") at position: " + other.transform.position);
            Destroy(gameObject);
        }
    }
}