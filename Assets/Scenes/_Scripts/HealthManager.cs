using UnityEngine;
using UnityEngine.UI; // Needed for the Green Bar
using UnityEngine.SceneManagement; // Needed to restart the game

public class HealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI Reference")]
    public Image healthBarFill; // Drag the Green Bar image here

    void Start()
    {
        // Reset health to full when game starts
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Detects when we hit the Enemy directly (Crash)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(20f); // Lose 20 health
            Destroy(other.gameObject); // Destroy the virus
        }
    }

    // Called when we hit something hurtful
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // Keep health between 0 and 100
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        // --- NEW: Screen Shake on Impact ---
        // Big shake (0.3 intensity) for 0.2 seconds
        if (CameraShake.instance != null)
        {
            CameraShake.instance.Shake(0.2f, 0.3f);
        }
        // -----------------------------------

        // Check if dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Called by Health Packs
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        // Show the Game Over screen instead of restarting
        if (GameOverManager.instance != null)
        {
            GameOverManager.instance.ShowGameOver();
        }
    }
}