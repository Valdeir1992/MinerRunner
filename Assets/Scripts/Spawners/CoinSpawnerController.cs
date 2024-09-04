using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerController : MonoBehaviour
{
    private float _speed;
    private HashSet<CollectibleCoin> _currentCoins;
    private ObjectPool<CollectibleCoin> _coinPooling;
    [SerializeField] private CollectibleCoin _coinPrefab;
    [SerializeField] private CoinSpawnerDataSO _spawerSO;

   private void Awake(){
    _currentCoins = new HashSet<CollectibleCoin>();
    _coinPooling = new ObjectPool<CollectibleCoin>();
    _coinPooling.InitializePool(_coinPrefab);
   } 
   private void Start(){
    SetSpeed(10);
   }
    private void Update(){
        foreach(var session in _currentCoins){
            session.transform.position += Time.deltaTime * _speed * -Vector3.forward;
        }
    }
    public void SetSpeed(float speed){
        _speed = speed;
    }
    public IEnumerator Coroutine_Spawn()
    {
        var scoreManager = FindAnyObjectByType<ScoreManager>();
        yield return new WaitForSeconds(_spawerSO.SpawnInterval);
        // Escolhe aleatoriamente uma linha para spawn
        float laneX = _spawerSO.Lanes[Random.Range(0, _spawerSO.Lanes.Length)];

        for (int i = 0; i < _spawerSO.CoinsPerRow; i++)
        {
            CollectibleCoin coin = _coinPooling.GetFromPool();
            _currentCoins.Add(coin);
            coin.OnCollect += ()=> scoreManager.AddScore(10);
            coin.OnRealease += ()=>{
                 _coinPooling.ReturnToPool(coin);
                 _currentCoins.Remove(coin);
            };
            

            // Calcula a posi��o de cada moeda na fileira
            float zOffset = i * _spawerSO.DistanceBetweenCoins;
            Vector3 spawnPosition = new Vector3(laneX, _spawerSO.SpawnHeight, Camera.main.transform.position.z + _spawerSO.SpawnDistance + zOffset);
            coin.transform.position = spawnPosition;
        }
    } 
}
