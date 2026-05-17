using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} died");
        // リスポーンやリセットは GameManager 側でやる想定でもOK
    }
}

