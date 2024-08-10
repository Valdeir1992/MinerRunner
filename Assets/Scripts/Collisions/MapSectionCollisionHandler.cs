using UnityEngine;

public class MapSectionCollisionHandler : MonoBehaviour
{
    private MapPool mapPool;

    // Inicializa a refer�ncia ao MapPool
    public void Initialize(MapPool pool)
    {
        mapPool = pool;
    }

    // Detecta a colis�o com o objeto "barrier"
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tentando detectar colis�o com: " + other.name + ", tag: " + other.tag);

        if (other.CompareTag("barrier")) // Verifica se o objeto � o trigger de reciclagem
        {
            Debug.Log("Colis�o detectada com o barrier pelo trecho: " + gameObject.name);
            mapPool.RecycleSection(gameObject);
        }
    }


}
