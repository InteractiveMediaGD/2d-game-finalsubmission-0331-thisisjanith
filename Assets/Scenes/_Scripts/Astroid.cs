using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Rotation")]
    public float rotationSpeed = 200f;

    [Header("Audio")]
    public AudioClip blastSound;

    void Start()
    {
        // Randomize rotation speed so some spin left, some spin right
        rotationSpeed = Random.Range(50f, 200f) * (Random.value > 0.5f ? 1 : -1);

        // Randomize move speed slightly for variety
        moveSpeed = Random.Range(3f, 6f);
    }

    void Update()
    {
        // 1. Move Left relative to the WORLD (Screen), not the object
        // "Space.World" is the secret ingredient here!
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime, Space.World);

        // 2. Rotate around its own center
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // 3. Destroy if off-screen
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    // Damage logic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play blast sound effect
            if (blastSound != null)
            {
                AudioSource.PlayClipAtPoint(blastSound, transform.position);
            }

            // Player takes damage logic is handled by the Player's HealthManager
            // We just destroy the asteroid so it doesn't hit twice
            Destroy(gameObject);
        }
    }
}