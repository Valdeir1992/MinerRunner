using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    private ObjectPool pool;
    public float moveSpeed = 5f; // Velocidade de movimento das moedas

    private void Start()
    {
        pool = ObjectPool.Instance; // Obt�m a refer�ncia do pool
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumenta a pontua��o
            ScoreManager.Instance.AddScore(100);
            // Retorna o objeto ao pool
            pool.ReturnToPool(gameObject);
        }
    }

    private void Update()
    {
        // Move a moeda para o jogador no eixo Z
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Retorna a moeda ao pool se ela sair da tela
        if (transform.position.z < Camera.main.transform.position.z - 10) // Ajuste conforme necess�rio
        {
            pool.ReturnToPool(gameObject);
        }
    }
}
