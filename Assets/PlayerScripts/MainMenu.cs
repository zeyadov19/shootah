using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start Game clicked!");

        // Make sure scene at index 1 exists and is added to build settings
        SceneManager.LoadScene(1);
    }
}



