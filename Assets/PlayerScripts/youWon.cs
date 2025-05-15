using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Level Complete! Loading next scene...");
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("Last level reached. No more scenes.");
            // Optional: Load main menu or victory screen
            // SceneManager.LoadScene("MainMenu");
        }
    }
}

