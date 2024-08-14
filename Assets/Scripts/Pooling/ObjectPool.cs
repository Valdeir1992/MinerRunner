using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T:MonoBehaviour
{ 
    private int poolSize = 10;
    private GameObject _prefab;
    private Queue<T> coinPool = new Queue<T>(); 

    public void InitializePool(GameObject prefab)
    {
        _prefab = prefab;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = GameObject.Instantiate(_prefab);
            coin.SetActive(false);
            coinPool.Enqueue(coin.GetComponent<T>());
        }
    }

    public T GetFromPool()
    {
        if (coinPool.Count > 0)
        {
            T coin = coinPool.Dequeue();
            coin.gameObject.SetActive(true);
            return coin;
        }
        else
        {
            T coin = GameObject.Instantiate(_prefab) as T;
            coin.gameObject.SetActive(true);
            return coin;
        }
    }

    public void ReturnToPool(T gameObject)
    {
        gameObject.gameObject.SetActive(false);
        coinPool.Enqueue(gameObject);
    }
}
