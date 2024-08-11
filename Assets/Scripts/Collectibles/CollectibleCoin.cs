using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    private float baseMoveSpeed = 15f; // Velocidade base de movimentação das moedas
    public float speedIncrement = 0.1f; // Incremento fixo da velocidade
    private float moveSpeed; // Velocidade atual de movimentação das moedas
    private ObjectPool pool;

    private void Start()
    {
        pool = ObjectPool.Instance; // Obtém a referência do pool
        moveSpeed = baseMoveSpeed; // Inicializa a velocidade de movimento com a base
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
        Debug.Log(moveSpeed);
        // Incrementa a velocidade base a cada atualização
        moveSpeed += speedIncrement * Time.deltaTime;
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
