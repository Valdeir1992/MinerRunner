using System.Collections;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private float _currentSpeed = 10;
    private CoinSpawnerController _coinSpawner;
    private MapSessionSpawnerController _mapSessionSpawner;
    private ObstacleSpawnerController _obstacleSpawner;

    private void Awake(){
        _coinSpawner = FindAnyObjectByType<CoinSpawnerController>();
        _mapSessionSpawner = FindAnyObjectByType<MapSessionSpawnerController>();
        _obstacleSpawner = FindAnyObjectByType<ObstacleSpawnerController>();
    }
    private void Start(){
        InvokeRepeating(nameof(this.Spawn),3,10);
    }
    private void Spawn(){
        StartCoroutine(_coinSpawner.Coroutine_Spawn());
        StartCoroutine(_obstacleSpawner.Coroutine_Spawn());
    } 
    private IEnumerator Coroutine_SpeedUp(){
        while(true){
            _currentSpeed +=0.2f;
            _mapSessionSpawner.SetSpeed(_currentSpeed);
            _coinSpawner.SetSpeed(_currentSpeed);
            _obstacleSpawner.SetSpeed(_currentSpeed);
            yield return new WaitForSeconds(10);
        }
    }
}
