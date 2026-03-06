using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;

    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Audio")]
    public AudioClip shootSound;
    private AudioSource audioSource;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 1. Movement Inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 2. Clamp Player to Screen (Adjust these if you hit the edge too soon)
        float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(xClamped, yClamped, transform.position.z);

        // 3. Shooting Input (Left Mouse Button or Space)
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed;
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Instantiate the bullet
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // Play shoot sound effect
            if (audioSource != null && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }
}