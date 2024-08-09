using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject prefab; // Prefab do trilho
    public int poolSize = 5;  // Tamanho do pool
    public List<GameObject> pool;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject(Transform parent)
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                obj.transform.SetParent(parent, false); // Configura o parentesco sem alterar a escala local ou posição relativa
                obj.transform.position = parent.position; // Opcional: ajusta a posição inicial
                return obj;
            }
        }

        // Se todos os objetos estão ativos, cria e adiciona um novo ao pool
        GameObject newObj = Instantiate(prefab, parent);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }


    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
