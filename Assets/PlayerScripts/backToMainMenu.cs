using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void MainGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}