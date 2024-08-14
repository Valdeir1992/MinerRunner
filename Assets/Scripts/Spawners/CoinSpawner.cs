using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private ObjectPool<CollectibleCoin> _coinPooling;
    [SerializeField] private GameObject _coinPrefab;
   [SerializeField] private CoinSpawnerDataSO _spawerSO;

   private void Awake(){
    _coinPooling = new ObjectPool<CollectibleCoin>();
    _coinPooling.InitializePool(_coinPrefab);
   }
    private void Start()
    {
        InvokeRepeating("SpawnCoinRow", 0f, _spawerSO.SpawnInterval);
    }

    private void SpawnCoinRow()
    {
        // Escolhe aleatoriamente uma linha para spawn
        float laneX = _spawerSO.Lanes[Random.Range(0, _spawerSO.Lanes.Length)];

        for (int i = 0; i < _spawerSO.CoinsPerRow; i++)
        {
            CollectibleCoin coin = _coinPooling.GetFromPool();
            coin.OnRealeaser += ()=> _coinPooling.ReturnToPool(coin);
            

            // Calcula a posi��o de cada moeda na fileira
            float zOffset = i * _spawerSO.DistanceBetweenCoins;
            Vector3 spawnPosition = new Vector3(laneX, _spawerSO.SpawnHeight, Camera.main.transform.position.z + _spawerSO.SpawnDistance + zOffset);
            coin.transform.position = spawnPosition;
        }
    } 
}
