using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnDie;
    public Action<int> OnTakeDamage;
    private int maxHealth = 3; 
    private int currentHealth;

    [SerializeField] private GameOverManager _startGameOver;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        OnTakeDamage?.Invoke(currentHealth);
        Debug.Log("VIDA "+currentHealth);
        if (currentHealth <= 0)
        {
            Die();
            currentHealth = maxHealth; //Reseta a vida
        }
    }

    private void Die()
    {
        _startGameOver.ShowGameOver(); 
        Debug.Log("Player died!");
        OnDie?.Invoke();
    }
}
