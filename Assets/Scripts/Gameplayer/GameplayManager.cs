using System.Collections;
using TMPro.Examples;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private float _currentSpeed = 10;
    private CoinSpawnerController _coinSpawner;
    private MapSessionSpawnerController _mapSessionSpawner;
    private ObstacleSpawnerController _obstacleSpawner;
    private CameraController _cameraController;
    private ScoreManager _scoreManager;

    private void Awake(){
        _coinSpawner = FindAnyObjectByType<CoinSpawnerController>();
        _mapSessionSpawner = FindAnyObjectByType<MapSessionSpawnerController>();
        _obstacleSpawner = FindAnyObjectByType<ObstacleSpawnerController>();
        _cameraController = FindAnyObjectByType<CameraController>();
        _scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    private void Start(){
        InvokeRepeating(nameof(this.Spawn),3,10);
        StartCoroutine(Coroutine_SpeedUp());
        StartCoroutine(Coroutine_Distance());
        FindAnyObjectByType<FadeController>()?.FadeIn(null);
    }
    private void Spawn(){
        StartCoroutine(_coinSpawner.Coroutine_Spawn());
        StartCoroutine(_obstacleSpawner.Coroutine_Spawn());
    } 
    public IEnumerator Coroutine_CameraShake(float time, float intensity){
        _cameraController.Shake(intensity);
        yield return new WaitForSeconds(time);
        _cameraController.Shake(0);
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
    private IEnumerator Coroutine_Distance(){
        var scoreManager = FindAnyObjectByType<ScoreManager>();
        while(true){
            scoreManager.AddScore(1 + Mathf.CeilToInt(_currentSpeed));
            yield return new WaitForSeconds(1);
        }
    }
}
