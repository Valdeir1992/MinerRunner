using UnityEngine;

public class MapSectionScroller : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento no eixo Z
    public float resetPositionZ = -250f; // Posição Z que determina quando reciclar o trecho
    private MapPool mapPool;

    void Start()
    {
        mapPool = FindObjectOfType<MapPool>(); // Encontra a instância do MapPool
    }

    void Update()
    {
        // Move o trecho no eixo Z
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Verifica se o trecho passou do ponto de reset
        if (transform.position.z < resetPositionZ)
        {
            mapPool.RecycleSection(this.gameObject);
        }
    }
}
