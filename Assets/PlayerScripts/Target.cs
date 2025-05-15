using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    private bool isDead = false; // ✅ prevent multiple deaths

  public void TakeDamage(float amount)
{
    if (isDead) return;

    Debug.Log($"[Target] Hit — Health before: {health}, Damage: {amount}");
    health -= amount;
    Debug.Log($"[Target] Health after: {health}");

    if (health <= 0f)
    {
        Die();
    }
}


    void Die()
    {
        isDead = true;
        Debug.Log("Enemy Died");
        Destroy(gameObject);
    }
}


