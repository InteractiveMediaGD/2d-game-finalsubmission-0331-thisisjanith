using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    [Header("UI Reference")]
    public GameObject gameOverPanel; // Drag the Game Over panel here

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Make sure the panel is hidden when the game starts
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    // Called by HealthManager when the player dies
    public void ShowGameOver()
    {
        // Stop any camera shake immediately
        if (CameraShake.instance != null)
        {
            CameraShake.instance.StopShake();
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Freeze the game so enemies and everything stops
        Time.timeScale = 0f;
    }

    // Called by the "Restart" button
    public void RestartGame()
    {
        Time.timeScale = 1f; // Unfreeze before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Called by the "Exit" button
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Unfreeze before leaving
        SceneManager.LoadScene("Menu");
    }
}
