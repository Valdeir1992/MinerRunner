using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverMundo : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do mundo em direção ao jogador
    private Transform player;    // Referência ao transform do jogador

    void Start()
    {
        // Encontra o GameObject do jogador pelo nome ou de outra forma apropriada
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Movendo o mundo em direção ao jogador ao longo do eixo z
        float moveDistance = moveSpeed * Time.deltaTime;
        transform.Translate(0, 0, -moveDistance);

        // Ajusta a posição do mundo com base na posição atual do jogador
        if (player != null)
        {
            // Calcula a diferença de posição entre o mundo e o jogador
            float playerDistance = player.position.z - transform.position.z;

            // Se o jogador estiver à frente do mundo, move o mundo para a frente
            if (playerDistance > 0)
            {
                transform.Translate(0, 0, playerDistance);
            }
        }
    }
}
