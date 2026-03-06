using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject pauseMenuPanel;

    private bool isPaused = false;

    void Start()
    {
        // FIX FOR PROBLEM 2:
        // Automatically hide the pause menu and unfreeze time when the level starts.
        // This ensures a clean state even if you saved the scene with the panel on.
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }

        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; // FIX FOR PROBLEM 1: This stops the enemies
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // This makes them move again
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Always unfreeze before leaving the scene
        SceneManager.LoadScene("Menu");
    }
}