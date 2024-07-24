using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    public SpawnManager spawnManager;
    private int desiredLane = 1; // 0 = esquerda, 1 = meio, 2 = direita
    public float laneDistance = 4f; // Distância entre as lanes

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

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
