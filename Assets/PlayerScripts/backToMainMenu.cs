using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void MainGame()
    {
        Debug.Log("Start Game clicked!");

        // Make sure scene at index 1 exists and is added to build settings
        SceneManager.LoadScene(0);
    }
}