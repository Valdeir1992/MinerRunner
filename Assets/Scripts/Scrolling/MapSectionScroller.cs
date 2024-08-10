using UnityEngine;

public class MapSectionScroller : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidade de movimenta��o dos mapas
    private Transform playerTransform; // Refer�ncia ao jogador ou c�mera

    private void Start()
    {
        playerTransform = Camera.main.transform; // Obt�m a refer�ncia � c�mera principal
    }

    void Update()
    {
        // Mover o trecho no eixo Z
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Verifica se o trecho est� fora do campo de vis�o
        if (transform.position.z < playerTransform.position.z - 50f) // Ajuste conforme necess�rio
        {
            MapPool.Instance.RecycleSection(gameObject);
        }
    }
}
