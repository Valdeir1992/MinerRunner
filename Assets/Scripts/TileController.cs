using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class TileController :MonoBehaviour
{
    private ObjectPool<ITile> _tilePooling;
    [SerializeField] private GameObject[] _prefabTiles;

    private void Start()
    {
        StartPooling();
        _tilePooling.Get();
    }
    #region OBJECT POOLING

    /// <summary>
    /// Função para gerar pooling de objetos.
    /// </summary>
    private void StartPooling()
    {
        _tilePooling = new ObjectPool<ITile>(OnCreateTiles,OnGetTile,OnReleaseTiles,OnDestroyTile);
    }
    /// <summary>
    /// Função executada para cada tile ao liberar o pooling de objetos.
    /// </summary>
    /// <param name="tile"></param>
    private void OnDestroyTile(ITile tile)
    {
        Destroy(tile.GetTile());
    }

    /// <summary>
    /// Função executada em cada tile quando o tile retorna para o pooling
    /// </summary>
    /// <param name="tile"></param>
    private void OnReleaseTiles(ITile tile)
    {
        tile.GetTile().SetActive(false);
    }
    /// <summary>
    /// Função executada em cada tile quando recuperar do pooling.
    /// </summary>
    /// <param name="tile"></param>
    private void OnGetTile(ITile tile)
    {
        tile.GetTile().SetActive(true);
    }
    /// <summary>
    /// Função executada para instanciar cada tile do pooling
    /// </summary>
    /// <returns></returns>
    private ITile OnCreateTiles()
    { 
        return Instantiate(_prefabTiles.OrderBy(x=>Guid.NewGuid()).First()).GetComponent<ITile>();
    }
    #endregion
}
