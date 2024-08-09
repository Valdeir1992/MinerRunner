using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    public ObjectPooling trackPool;  // Referência ao pool de trilhos
    public float scrollSpeed = 5.0f;
    public float trackLength = 6.0f;  // Comprimento do modelo de trilho
    private Vector3 startPosition;
    public float[] lanePositionsX = new float[] { -3.5f, 0f, 3.5f }; // Posições X para as três fileiras

    void Start()
    {
        startPosition = transform.position;
        // Inicialmente instanciar os trilhos em três fileiras
        for (int lane = 0; lane < lanePositionsX.Length; lane++)
        {
            for (int i = 0; i < trackPool.poolSize; i++)
            {
                GameObject track = trackPool.GetObject(transform);
                track.transform.position = new Vector3(lanePositionsX[lane], startPosition.y, startPosition.z + i * trackLength);
            }
        }
    }

    void Update()
    {
        float farthestZ = float.NegativeInfinity;

        foreach (Transform child in transform)
        {
            child.position += Vector3.back * scrollSpeed * Time.deltaTime;

            if (child.position.z < startPosition.z - trackLength)
            {
                trackPool.ReturnObject(child.gameObject);
                child.gameObject.SetActive(false);
            }

            // Atualiza a posição mais distante
            if (child.position.z > farthestZ && child.gameObject.activeSelf)
            {
                farthestZ = child.position.z;
            }
        }

        // Reposiciona os trilhos retornados
        foreach (Transform child in transform)
        {
            if (!child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(true);
                child.position = new Vector3(child.position.x, startPosition.y, farthestZ + trackLength);
            }
        }
    }
}
