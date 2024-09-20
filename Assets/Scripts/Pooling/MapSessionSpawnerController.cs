using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapSessionSpawnerController : MonoBehaviour
{
    private ObjectPool<MapSection> _mapPooling = new ObjectPool<MapSection>();
    private HashSet<MapSection> _currentSessions;
    public MapSection[] allMapPrefabs; // Todos os prefabs dos mapas
    private const float SESSION_SIZE = 47.6f; // Tamanho de cada trecho do mapa  
    private const float FIX_X_POSITION = -0.1f; // Ajuste na posição X (fixa)
    private readonly Vector3 POOLING_START_POSITION = new Vector3(0, 10, 0); // Posição inicial do pooling
    private float _speed;
    public float Speed { get => _speed; }
    private const float OFFSCREEN_THRESHOLD = -80f; // Posição Z onde o mapa é considerado fora da tela

    private void Awake()
    {
        _currentSessions = new HashSet<MapSection>();
        _mapPooling.InitializePool(allMapPrefabs); // Inicializa o pooling com os prefabs dos mapas
    }

    private void Start()
    {
        SpawnInitialMaps(5); // Inicializa os primeiros 5 trechos do mapa
        SetSpeed(10); // Define a velocidade inicial do scroll
    }

    private void Update()
    {
        // Move cada trecho do mapa com base na velocidade
        foreach (var session in _currentSessions)
        {
            session.transform.position += Time.deltaTime * _speed * -Vector3.forward;

            // Verifica se o trecho saiu da tela
            if (session.transform.position.z < OFFSCREEN_THRESHOLD)
            {
                RecycleMapSection(session); // Reposiciona o trecho no final da fila
            }
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    // Ativa os primeiros trechos do mapa
    private void SpawnInitialMaps(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            MapSection mapToSpawn = _mapPooling.GetFromPool();
            mapToSpawn.OnRealeaser += () =>
            {
                SpawnSession();
                _mapPooling.ReturnToPool(mapToSpawn);
                mapToSpawn.transform.position = POOLING_START_POSITION;
                _currentSessions.Remove(mapToSpawn);
            };

            // Calcula a posição Z de cada trecho com base no seu tamanho
            var zNextPosition = SESSION_SIZE * i;
            mapToSpawn.transform.position = new Vector3(FIX_X_POSITION, 0, zNextPosition);
            _currentSessions.Add(mapToSpawn);
        }
    }

    // Spawna os próximos trechos do mapa
    private void SpawnSession()
    {
        MapSection mapToSpawn = _mapPooling.GetFromPool();
        _currentSessions.Add(mapToSpawn);

        mapToSpawn.OnRealeaser += () =>
        {
            SpawnSession();
            _mapPooling.ReturnToPool(mapToSpawn);
            _currentSessions.Remove(mapToSpawn);
        };

        // Seleciona o último trecho ativo no mapa e calcula a próxima posição Z
        var sessionsActives = _currentSessions.Where(x => x.isActiveAndEnabled).OrderBy(x => x.transform.position.z);
        var selected = sessionsActives.Last();
        var zNextPosition = selected.transform.position.z + SESSION_SIZE;

        // Define a posição do próximo trecho de mapa
        mapToSpawn.transform.position = new Vector3(FIX_X_POSITION, 0, zNextPosition);
    }

    // Reposiciona o trecho que saiu da tela para o final da fila
    private void RecycleMapSection(MapSection session)
    {
        var sessionsActives = _currentSessions.Where(x => x.isActiveAndEnabled).OrderBy(x => x.transform.position.z);
        var selected = sessionsActives.Last();
        var zNextPosition = selected.transform.position.z + SESSION_SIZE;

        session.transform.position = new Vector3(FIX_X_POSITION, 0, zNextPosition); // Reposiciona no final
    }
}
