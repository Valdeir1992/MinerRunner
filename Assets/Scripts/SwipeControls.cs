using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeMovement : MonoBehaviour
{
    public SpawnManager spawnManager;
    private GameInputs _gameinputs;
    private int desiredLane = 1; // 0 = esquerda, 1 = meio, 2 = direita
    public float laneDistance = 4f; // Distância entre as lanes

  
    private void Start()
    {
        _gameinputs = new GameInputs();
        _gameinputs.Gameplay.Enable();
        _gameinputs.Gameplay.Right.started += MoveToRight;
        _gameinputs.Gameplay.Left.started += MoveToLeft;
    }
    /// <summary>
    /// Move o personagem para esqueda.
    /// </summary>
    /// <param name="context">Recebe o contexto do InputSystem</param>
    /// <exception cref="NotImplementedException"></exception>
    private void MoveToLeft(InputAction.CallbackContext context)
    {
        desiredLane--;
        if (desiredLane == -1)
        {
            desiredLane = 0;
        }
        Debug.Log("Esquerda");
    }
    /// <summary>
    /// Move o personagem para direita.
    /// </summary>
    /// <param name="context">Recebe o contexto do InputSystem</param>
    /// <exception cref="NotImplementedException"></exception>
    private void MoveToRight(InputAction.CallbackContext context)
    {
        desiredLane++;
        if (desiredLane == 3)
        {
            desiredLane = 2;
        }
        Debug.Log("Direita");
    }

    private void Update()
    { 
         
        // Calcular a nova posição com base na lane desejada
        Vector3 targetPosition = transform.position;
        targetPosition.x = (desiredLane - 1) * laneDistance;

        // Atualizar a posição do jogador
        transform.position = targetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.TriggerEntered();
    }
}
