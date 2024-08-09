using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public GameObject coinPrefab;
    public int poolSize = 10;

    private Queue<GameObject> coinPool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);
            coinPool.Enqueue(coin);
        }
    }

    public GameObject GetFromPool()
    {
        if (coinPool.Count > 0)
        {
            GameObject coin = coinPool.Dequeue();
            coin.SetActive(true);
            return coin;
        }
        else
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(true);
            return coin;
        }
    }

    public void ReturnToPool(GameObject coin)
    {
        coin.SetActive(false);
        coinPool.Enqueue(coin);
    }
}
