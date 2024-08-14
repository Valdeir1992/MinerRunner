using UnityEngine;

[CreateAssetMenu(menuName ="Prototype/Spawn/Coin")]
public class CoinSpawnerDataSO:ScriptableObject{
    [SerializeField] private float _spawnInterval; // Intervalo entre spawn das fileiras
    [SerializeField] private float _spawnDistance; // Dist�ncia inicial para spawn das moedas no eixo Z (aumente conforme necess�rio)
    [SerializeField] private float _spawnHeight; // Altura no eixo Y para spawn
    [SerializeField] private int _coinsPerRow; // N�mero de moedas por fileira
    [SerializeField] private float _distanceBetweenCoins; // Dist�ncia entre as moedas na fileira
    [SerializeField] private float[] _lanes; // Posi��es X para as tr�s linhas

    public float SpawnInterval { get => _spawnInterval;}
    public float SpawnDistance { get => _spawnDistance;}
    public float SpawnHeight { get => _spawnHeight;}
    public int CoinsPerRow { get => _coinsPerRow;}
    public float DistanceBetweenCoins { get => _distanceBetweenCoins;}
    public float[] Lanes { get => _lanes;}
}
