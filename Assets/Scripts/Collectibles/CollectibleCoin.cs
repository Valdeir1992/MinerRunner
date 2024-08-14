using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    public Action OnRealeaser;
    private float baseMoveSpeed = 15f; // Velocidade base de movimenta��o das moedas
    public float speedIncrement = 0.1f; // Incremento fixo da velocidade
    private float moveSpeed; // Velocidade atual de movimenta��o das moedas 

    private void Start()
    { 
        moveSpeed = baseMoveSpeed; // Inicializa a velocidade de movimento com a base
    }

    private void Update()
    {
        AdjustMoveSpeed();

        // Move a moeda para o jogador no eixo Z
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Retorna a moeda ao pool se ela sair da tela
        if (transform.position.z < Camera.main.transform.position.z - 10) // Ajuste conforme necess�rio
        {
           Release();
        }
    }

    private void AdjustMoveSpeed()
    {
        Debug.Log(moveSpeed);
        // Incrementa a velocidade base a cada atualiza��o
        moveSpeed += speedIncrement * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumenta a pontua��o
            ScoreManager.Instance.AddScore(100);
            // Retorna o objeto ao pool
           Release();
        }
    }
    private void Release(){
        OnRealeaser?.Invoke();
        OnRealeaser = null;
    }
}
