using UnityEngine;
using System.Collections.Generic;

public class MapPool : MonoBehaviour
{
    public GameObject[] sectionPrefabs;
    public float sectionLength = 5f;
    public float additionalSpace = 1f;

    private Queue<GameObject> sectionQueue = new Queue<GameObject>();

    void Start()
    {
        InitializeSections();
    }

    void InitializeSections()
    {
        float currentZPosition = 0f;
        foreach (var prefab in sectionPrefabs)
        {
            GameObject instance = Instantiate(prefab, new Vector3(0, 0, currentZPosition), Quaternion.Euler(-90, 0, 0));
            sectionQueue.Enqueue(instance);
            currentZPosition += sectionLength + additionalSpace;
        }
    }

    public void RecycleSection(GameObject section)
    {
        // Reposiciona o trecho no final da fila
        sectionQueue.Dequeue();
        float lastSectionZ = sectionQueue.Peek().transform.position.z;
        float newPositionZ = lastSectionZ + sectionLength + additionalSpace;
        section.transform.position = new Vector3(0, 0, newPositionZ);
        sectionQueue.Enqueue(section);
    }
}
