using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverMundo : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do mundo em dire��o ao jogador
    private Transform player;    // Refer�ncia ao transform do jogador

    void Start()
    {
        // Encontra o GameObject do jogador pelo nome ou de outra forma apropriada
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Movendo o mundo em dire��o ao jogador ao longo do eixo z
        float moveDistance = moveSpeed * Time.deltaTime;
        transform.Translate(0, 0, -moveDistance);

        // Ajusta a posi��o do mundo com base na posi��o atual do jogador
        if (player != null)
        {
            // Calcula a diferen�a de posi��o entre o mundo e o jogador
            float playerDistance = player.position.z - transform.position.z;

            // Se o jogador estiver � frente do mundo, move o mundo para a frente
            if (playerDistance > 0)
            {
                transform.Translate(0, 0, playerDistance);
            }
        }
    }
}
