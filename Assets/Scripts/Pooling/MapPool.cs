using UnityEngine;
using System.Collections.Generic;

public class MapPool : MonoBehaviour
{
    public static MapPool Instance;
    public GameObject[] allMapPrefabs;  // Todos os prefabs dos mapas
    private List<MapInfo> mapInfos = new List<MapInfo>();  // Lista de informações sobre mapas

    [System.Serializable]
    public class MapInfo
    {
        public GameObject mapObject;
        public float length;  // Comprimento do mapa no eixo Z
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeMapPool();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeMapPool()
    {
        foreach (var prefab in allMapPrefabs)
        {
            GameObject mapInstance = Instantiate(prefab, Vector3.zero, Quaternion.Euler(-90, 0, 0));
            mapInstance.SetActive(false);
            float mapLength = mapInstance.GetComponent<Renderer>().bounds.size.z; // Assume a orientação correta
            mapInfos.Add(new MapInfo { mapObject = mapInstance, length = mapLength });
        }
    }

    public void SpawnInitialMaps()
    {
        float currentZPosition = 0f;
        for (int i = 0; i < 2; i++)  // Spawn inicial de dois mapas
        {
            var mapInfo = mapInfos[i];
            mapInfo.mapObject.transform.position = new Vector3(0, 0, currentZPosition);
            mapInfo.mapObject.SetActive(true);
            // Atualiza a posição Z para o próximo mapa
            currentZPosition += mapInfo.length;
        }
    }

    public void RecycleSection(GameObject map)
    {
        map.SetActive(false);
        // Encontrar informações do mapa
        MapInfo info = mapInfos.Find(m => m.mapObject == map);
        if (info != null)
        {
            // Seleciona um novo mapa aleatoriamente para substituir o mapa reciclado
            var newMapInfo = mapInfos[Random.Range(0, mapInfos.Count)];
            float newPositionZ = CalculateNewMapPosition();
            newMapInfo.mapObject.transform.position = new Vector3(0, 0, newPositionZ);
            newMapInfo.mapObject.SetActive(true);
        }
    }

    private float CalculateNewMapPosition()
    {
        // Retorna a posição baseado no mapa atualmente visível mais distante
        float maxZ = 0;
        foreach (var info in mapInfos)
        {
            if (info.mapObject.activeSelf && info.mapObject.transform.position.z < maxZ)
                maxZ = info.mapObject.transform.position.z - info.length;
        }
        return maxZ;
    }
}
