using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnDie;
    public Action<int> OnTakeDamage;
    private int maxHealth = 3;
    public int currentHealth;

    [SerializeField] private GameOverManager _startGameOver;
    [SerializeField] private PlayerDamageVisual _playerDamageVisual;
    [SerializeField] private LifeText _lifeText;



    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        OnTakeDamage?.Invoke(currentHealth);
        _lifeText.ShowLife();
        
        StartCoroutine(_playerDamageVisual.Coroutine_Blink());

        if (currentHealth <= 0)
        {
            Die();
            currentHealth = maxHealth; //Reseta a vida
        }
    }

    private void Die()
    {
        Instantiate(_startGameOver); //Chama menu de Game Over
        OnDie?.Invoke();
    }
}
