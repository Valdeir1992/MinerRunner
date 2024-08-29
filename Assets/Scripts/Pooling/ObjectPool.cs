using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T:MonoBehaviour
{ 
    private int poolSize = 10;
    private T _prefab;
    private T[] _prefabs;
    private HashSet<T> _pool = new HashSet<T>(); 

    public void InitializePool(T prefab, int amount =10)
    {
        _prefab = prefab;
        poolSize = amount;
        for (int i = 0; i < poolSize; i++)
        {
            T current = GameObject.Instantiate(_prefab);
            current.name = $"Pool {typeof(T)} {_pool.Count}";
            current.gameObject.SetActive(false);
            _pool.Add(current.GetComponent<T>());
        }
    }
    public void InitializePool(T[] prefabs, int amount =10){ 
        poolSize = amount;
        _prefabs = prefabs;
        for (int i = 0; i < poolSize; i++)
        {
            T current = GameObject.Instantiate(prefabs[UnityEngine.Random.Range(0,prefabs.Length)]);
            current.name = $"Pool {typeof(T)} {_pool.Count}";
            current.gameObject.SetActive(false);
            _pool.Add(current.GetComponent<T>());
        }
    }

    public T GetFromPool()
    {
        T selected = default;
        foreach(var current in _pool){
            if(current.gameObject.activeInHierarchy){
                continue;
            }
            selected = current;
            selected.gameObject.SetActive(true); 
            _pool.Remove(selected);
            return selected;
        }
        selected = GameObject.Instantiate((ReferenceEquals(_prefabs,null))?_prefab:_prefabs[UnityEngine.Random.Range(0,_prefabs.Length)]) as T; 
        selected.gameObject.SetActive(false);
        _pool.Add(selected);
        return GetFromPool();
    }

    public void ReturnToPool(T target)
    { 
        target.gameObject.SetActive(false);
        _pool.Add(target);
    }
}
