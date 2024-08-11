using UnityEngine;

public class MapSectionScroller : MonoBehaviour
{
    private float baseMoveSpeed = 15f; // Velocidade base de movimentação dos mapas
    public float speedIncrement = 0.1f; // Incremento fixo da velocidade
    private float moveSpeed; // Velocidade atual de movimentação dos mapas
    public float recyclePositionZ = -50f; // Posição Z para reciclagem
    private MapPool mapPool; // Referência ao MapPool

    private void Start()
    {
        mapPool = MapPool.Instance; // Obtém a referência ao MapPool
        moveSpeed = baseMoveSpeed; // Inicializa a velocidade de movimento com a base
    }

    void Update()
    {
        AdjustMoveSpeed(); // Ajusta a velocidade de movimento

        // Mover o trecho no eixo Z
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Verifica se o trecho está fora do campo de visão
        if (transform.position.z < recyclePositionZ) // Usa a variável de reciclagem
        {
            mapPool.RecycleSection(gameObject);
        }
    }

    private void AdjustMoveSpeed()
    {
        Debug.Log(moveSpeed);
        // Incrementa a velocidade base a cada atualização
        moveSpeed += speedIncrement * Time.deltaTime;
    }
}
