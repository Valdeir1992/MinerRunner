using UnityEngine;
using System.Collections.Generic;

public class MapPool : MonoBehaviour
{
    public static MapPool Instance; // Singleton para acesso global
    public GameObject[] allMapPrefabs; // Todos os prefabs dos mapas
    public float prefabSize = 50f; // Tamanho de cada trecho do mapa
    public float additionalSpace = 5f; // Espaço adicional entre trechos
    public float spawnPositionZ = 0f; // Posição exata de spawn para novos trechos

    private Queue<GameObject> mapQueue = new Queue<GameObject>(); // Fila para gerenciar os trechos

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        InitializeMapPool();
        SpawnInitialMaps();
    }

    // Inicializa a pool com os prefabs
    void InitializeMapPool()
    {
        float currentZPosition = 0f;
        foreach (var prefab in allMapPrefabs)
        {
            GameObject instance = Instantiate(prefab, new Vector3(0, 0, currentZPosition), Quaternion.Euler(-90, 0, 0));
            instance.SetActive(false); // Desativa o trecho até que seja necessário
            mapQueue.Enqueue(instance);
            currentZPosition += (prefabSize + additionalSpace);
        }
    }

    // Ativa os primeiros dois trechos na fila
    void SpawnInitialMaps()
    {
        for (int i = 0; i < 2; i++)
        {
            if (mapQueue.Count > 0)
            {
                GameObject mapToSpawn = mapQueue.Dequeue();
                mapToSpawn.SetActive(true);
                mapQueue.Enqueue(mapToSpawn);
            }
        }
    }

    // Recicla o trecho do mapa que saiu de vista
    public void RecycleSection(GameObject section)
    {
        mapQueue.Dequeue(); // Remove o trecho atual da fila
        section.SetActive(false); // Desativa o trecho que saiu de vista

        // Usa a posição de spawn configurada
        section.transform.position = new Vector3(0, 0, spawnPositionZ);
        section.SetActive(true);

        // Reenfileira o trecho reciclado no final da fila
        mapQueue.Enqueue(section);
    }
}
