using UnityEngine;

public class MapSectionScroller : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidade de movimentação dos mapas
    private Transform playerTransform; // Referência ao jogador ou câmera

    private void Start()
    {
        playerTransform = Camera.main.transform; // Obtém a referência à câmera principal
    }

    void Update()
    {
        // Mover o trecho no eixo Z
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Verifica se o trecho está fora do campo de visão
        if (transform.position.z < playerTransform.position.z - 50f) // Ajuste conforme necessário
        {
            MapPool.Instance.RecycleSection(gameObject);
        }
    }
}
