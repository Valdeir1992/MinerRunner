using System.Collections;
using System.Collections.Generic; 
using System.Linq; 
using UnityEngine; 

public class MapSessionSpawnerController : MonoBehaviour
{ 
    private ObjectPool<MapSection> _mapPooling = new ObjectPool<MapSection>();
    private HashSet<MapSection> _currentSessions;
    public MapSection[] allMapPrefabs; // Todos os prefabs dos mapas
    private const float SESSION_SIZE = 33.3f; // Tamanho de cada trecho do mapa  
    private const float FIX_X_POSITION = -0.1f;
    private readonly Vector3 POOLING_START_POSITION = new Vector3(0,10,0);
    private float _speed;
    public float Speed {get=>_speed;}

    private void Awake(){
        _currentSessions = new HashSet<MapSection>();
        _mapPooling.InitializePool(allMapPrefabs);
    }

    private void Start()
    {
        SpawnInitialMaps(5); 
        SetSpeed(10);
    } 
    private void Update(){
        foreach(var session in _currentSessions){
            session.transform.position += Time.deltaTime * _speed * -Vector3.forward;
        }
    }
    public void SetSpeed(float speed){
        _speed = speed;
    }
    // Ativa os primeiros dois trechos na fila
    private void SpawnInitialMaps(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            MapSection mapToSpawn = _mapPooling.GetFromPool(); 
            mapToSpawn.OnRealeaser += ()=> {
                SpawnSession();
                _mapPooling.ReturnToPool(mapToSpawn);
                mapToSpawn.transform.position = POOLING_START_POSITION; 
                _currentSessions.Remove(mapToSpawn);  
            }; 
            mapToSpawn.transform.position = new Vector3(FIX_X_POSITION,0,33 * i); 
            _currentSessions.Add(mapToSpawn);
        }
    } 
    private void SpawnSession(){ 
            MapSection mapToSpawn = _mapPooling.GetFromPool();  
            _currentSessions.Add(mapToSpawn);
            mapToSpawn.OnRealeaser += ()=> { 
                SpawnSession();
                _mapPooling.ReturnToPool(mapToSpawn);
                _currentSessions.Remove(mapToSpawn);  
            };              
            var sessionsActives = _currentSessions.Where(x=>x.isActiveAndEnabled).OrderBy(x=>x.transform.position.z);
            var selected = sessionsActives.Last();
            var zNextPosition = selected.transform.position.z + SESSION_SIZE;
            mapToSpawn.transform.position = new Vector3(FIX_X_POSITION,0,zNextPosition);  
    } 
}
