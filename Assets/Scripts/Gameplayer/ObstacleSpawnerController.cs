using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerController:MonoBehaviour{
    private float _speed;
    private HashSet<Obstacle> _currentObstacle;
    private ObjectPool<Obstacle> _obstaclePooling;
    [SerializeField] private Obstacle[] _obstaclePrefab;
    [SerializeField] private ObstacleSpawnerDataSO _spawerSO;

   private void Awake(){
    _currentObstacle = new HashSet<Obstacle>();
    _obstaclePooling = new ObjectPool<Obstacle>();
    _obstaclePooling.InitializePool(_obstaclePrefab);
   } 
   private void Start(){
    SetSpeed(10);
   }
    private void Update(){
        foreach(var session in _currentObstacle){
            session.transform.position += Time.deltaTime * _speed * -Vector3.forward;
        }
    }
    public void SetSpeed(float speed){
        _speed = speed;
    }
    public IEnumerator Coroutine_Spawn()
    {
        yield return new WaitForSeconds(_spawerSO.SpawnInterval);
        // Escolhe aleatoriamente uma linha para spawn
        float laneX = _spawerSO.Lanes[UnityEngine.Random.Range(0, _spawerSO.Lanes.Length)];

      Obstacle obstacle = _obstaclePooling.GetFromPool();
            _currentObstacle.Add(obstacle);
            obstacle.OnRealease += ()=>{
                 _obstaclePooling.ReturnToPool(obstacle);
                 _currentObstacle.Remove(obstacle);
            };
            
            Vector3 spawnPosition = new Vector3(laneX, _spawerSO.SpawnHeight, Camera.main.transform.position.z + _spawerSO.SpawnDistance);
            obstacle.transform.position = spawnPosition;
    } 
}
