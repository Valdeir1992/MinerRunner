using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float spawnInterval = 2.0f; // Intervalo entre spawn das fileiras
    public float spawnDistance = 30f; // Dist�ncia inicial para spawn das moedas no eixo Z (aumente conforme necess�rio)
    public float spawnHeight = 1f; // Altura no eixo Y para spawn
    public int coinsPerRow = 3; // N�mero de moedas por fileira
    public float distanceBetweenCoins = 1f; // Dist�ncia entre as moedas na fileira
    private float[] lanes = new float[] { -2f, 0f, 2f }; // Posi��es X para as tr�s linhas

    private void Start()
    {
        InvokeRepeating("SpawnCoinRow", 0f, spawnInterval);
    }

    private void SpawnCoinRow()
    {
        // Escolhe aleatoriamente uma linha para spawn
        float laneX = lanes[Random.Range(0, lanes.Length)];

        for (int i = 0; i < coinsPerRow; i++)
        {
            GameObject coin = ObjectPool.Instance.GetFromPool();

            // Calcula a posi��o de cada moeda na fileira
            float zOffset = i * distanceBetweenCoins;
            Vector3 spawnPosition = new Vector3(laneX, spawnHeight, Camera.main.transform.position.z + spawnDistance + zOffset);
            coin.transform.position = spawnPosition;
        }
    }
}
