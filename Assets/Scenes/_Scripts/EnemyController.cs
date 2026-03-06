using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;

    [Header("Audio")]
    public AudioClip blastSound;

    void Update()
    {
        // 1. Calculate Current Speed
        // We multiply the base speed by the DifficultyManager's globalSpeed.
        // As the game goes on, globalSpeed rises (1.0 -> 1.5 -> 2.0), making enemies faster.
        float currentSpeed = speed * DifficultyManager.globalSpeed;

        // 2. Move Left
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        // 3. Cleanup
        // Destroy if it goes off the left side of the screen
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    // Optional: Destroy if the enemy hits the player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play blast sound effect
            if (blastSound != null)
            {
                AudioSource.PlayClipAtPoint(blastSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}