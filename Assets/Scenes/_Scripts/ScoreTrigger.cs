using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the Player passes through this invisible line
        if (other.CompareTag("Player"))
        {
            // Add 10 points
            ScoreManager.instance.AddScore(10);

            // Destroy this trigger so we don't score twice for the same line
            Destroy(gameObject);
        }
    }
}