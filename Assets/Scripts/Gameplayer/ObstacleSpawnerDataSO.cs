using UnityEngine;

[CreateAssetMenu(menuName = "Miner runner/Data/Obstacle")]
public class ObstacleSpawnerDataSO : ScriptableObject
{
    [SerializeField] private int[] _lanes;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _spawnHeight;
    [SerializeField] private float _spawnDistance;
    public float SpawnInterval { get=>_spawnInterval;}
    public int[] Lanes { get=>_lanes;}
    public float SpawnHeight { get=>_spawnHeight; }
    public float SpawnDistance { get=>_spawnDistance;}
}
