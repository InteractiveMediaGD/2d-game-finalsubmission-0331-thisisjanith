using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Makes this easy to access from other scripts
    public TextMeshProUGUI scoreText; // Reference to the UI Text

    private int score = 0;

    void Awake()
    {
        // Set up the "Singleton" so we can call ScoreManager.instance anywhere
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        ResetScore();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}