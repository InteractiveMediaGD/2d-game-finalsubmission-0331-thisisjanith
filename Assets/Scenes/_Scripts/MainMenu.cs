using UnityEngine;
using UnityEngine.SceneManagement; // Required to change scenes

public class MainMenu : MonoBehaviour
{
    // This function will be called by the "Play" button
    public void PlayGame()
    {
        // Loads the scene named "SampleScene" (or whatever your game scene is called)
        // Make sure your game scene name matches exactly!
        SceneManager.LoadScene("SampleScene");
    }

    // This function will be called by the "Quit" button
    public void QuitGame()
    {
        Debug.Log("QUIT GAME REQUESTED"); // Shows in editor to prove it works
        Application.Quit();
    }
}