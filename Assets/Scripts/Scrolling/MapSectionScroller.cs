using UnityEngine;

public class MapSectionScroller : MonoBehaviour
{
    private float baseMoveSpeed = 15f; // Velocidade base de movimenta��o dos mapas
    public float speedIncrement = 0.1f; // Incremento fixo da velocidade
    private float moveSpeed; // Velocidade atual de movimenta��o dos mapas
    public float recyclePositionZ = -50f; // Posi��o Z para reciclagem
    private MapPool mapPool; // Refer�ncia ao MapPool

    private void Start()
    {
        mapPool = MapPool.Instance; // Obt�m a refer�ncia ao MapPool
        moveSpeed = baseMoveSpeed; // Inicializa a velocidade de movimento com a base
    }

    void Update()
    {
        AdjustMoveSpeed(); // Ajusta a velocidade de movimento

        // Mover o trecho no eixo Z
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Verifica se o trecho est� fora do campo de vis�o
        if (transform.position.z < recyclePositionZ) // Usa a vari�vel de reciclagem
        {
            mapPool.RecycleSection(gameObject);
        }
    }

    private void AdjustMoveSpeed()
    {
        Debug.Log(moveSpeed);
        // Incrementa a velocidade base a cada atualiza��o
        moveSpeed += speedIncrement * Time.deltaTime;
    }
}
