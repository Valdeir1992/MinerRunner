using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    private ObjectPool pool;
    private float moveSpeed; // Velocidade de movimento das moedas

    private void Start()
    {
        pool = ObjectPool.Instance; // Obtém a referência do pool
    }

    private void Update()
    {
        AdjustMoveSpeed();

        // Move a moeda para o jogador no eixo Z
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Retorna a moeda ao pool se ela sair da tela
        if (transform.position.z < Camera.main.transform.position.z - 10) // Ajuste conforme necessário
        {
            pool.ReturnToPool(gameObject);
        }
    }

    private void AdjustMoveSpeed()
    {
        int score = ScoreManager.Instance.CurrentScore;

        if (score < 1000)
        {
            moveSpeed = 10f;
        }
        else if (score < 2000)
        {
            moveSpeed = 15f;
        }
        else if (score < 3000)
        {
            moveSpeed = 25f;
        }
        else
        {
            moveSpeed = 25f + ((score - 3000) / 1000) * 0.5f; // Incremento de 0.5 por cada 1000 pontos acima de 3000
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumenta a pontuação
            ScoreManager.Instance.AddScore(100);
            // Retorna o objeto ao pool
            pool.ReturnToPool(gameObject);
        }
    }
}
