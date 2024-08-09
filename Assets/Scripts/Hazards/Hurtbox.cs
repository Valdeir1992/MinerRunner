using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public int damage = 10; // Quantidade de dano causado ao jogador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Certifique-se de que o jogador tem a tag "Player"
        {
            // Aplica dano ao jogador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
