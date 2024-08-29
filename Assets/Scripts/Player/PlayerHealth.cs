using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnDie;
    public Action<int> OnTakeDamage;
    public int maxHealth = 100;
    private int currentHealth; 

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        OnTakeDamage?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        OnDie?.Invoke();
    }
}
