using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float d)
    {
        currentHealth -= d;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}