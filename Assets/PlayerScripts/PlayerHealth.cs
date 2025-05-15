using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Slider healthSlider;           // UI health bar
    public GameObject gameOverPanel;      // UI GameOver panel

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Hide Game Over at start

        Time.timeScale = 1f; // Ensure game is running
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage. Current health: " + currentHealth);
        UpdateHealthUI();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player died!");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void RestartGame()
{
    Debug.Log("Restart button clicked!");

    Time.timeScale = 1f;

    string sceneName = SceneManager.GetActiveScene().name;
    Debug.Log("Reloading scene: " + sceneName);

    SceneManager.LoadScene(sceneName);
}

}



