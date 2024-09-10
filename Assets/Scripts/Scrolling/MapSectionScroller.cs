using UnityEngine;

public class MapSectionScroller : MonoBehaviour
{
    private float baseMoveSpeed = 15f; // Velocidade base de movimenta��o dos mapas
    public float speedIncrement = 0.1f; // Incremento fixo da velocidade
    private float moveSpeed; // Velocidade atual de movimenta��o dos mapas
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
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); // Corrige a dire��o de movimento

        // Verifica se o trecho est� fora do campo de vis�o da c�mera
        if (!IsInView())
        {
            mapPool.RecycleSection(gameObject);
        }
    }

    private void AdjustMoveSpeed()
    {
        moveSpeed += speedIncrement * Time.deltaTime; // Incrementa a velocidade base a cada atualiza��o
    }

    // Verifica se o mapa ainda est� vis�vel pela c�mera principal
    bool IsInView()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }
}
