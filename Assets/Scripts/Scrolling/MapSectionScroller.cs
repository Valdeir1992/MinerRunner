using UnityEngine;

public class MapSectionScroller : MonoBehaviour
{
    private float baseMoveSpeed = 15f; // Velocidade base de movimentação dos mapas
    public float speedIncrement = 0.1f; // Incremento fixo da velocidade
    private float moveSpeed; // Velocidade atual de movimentação dos mapas
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
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); // Corrige a direção de movimento

        // Verifica se o trecho está fora do campo de visão da câmera
        if (!IsInView())
        {
            mapPool.RecycleSection(gameObject);
        }
    }

    private void AdjustMoveSpeed()
    {
        moveSpeed += speedIncrement * Time.deltaTime; // Incrementa a velocidade base a cada atualização
    }

    // Verifica se o mapa ainda está visível pela câmera principal
    bool IsInView()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }
}
