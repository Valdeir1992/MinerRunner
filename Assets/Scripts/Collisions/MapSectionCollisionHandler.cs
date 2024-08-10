using UnityEngine;

public class MapSectionCollisionHandler : MonoBehaviour
{
    private MapPool mapPool;

    // Inicializa a referência ao MapPool
    public void Initialize(MapPool pool)
    {
        mapPool = pool;
    }

    // Detecta a colisão com o objeto "barrier"
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tentando detectar colisão com: " + other.name + ", tag: " + other.tag);

        if (other.CompareTag("barrier")) // Verifica se o objeto é o trigger de reciclagem
        {
            Debug.Log("Colisão detectada com o barrier pelo trecho: " + gameObject.name);
            mapPool.RecycleSection(gameObject);
        }
    }


}
