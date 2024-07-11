using UnityEngine;

public class TileBase : MonoBehaviour, ITile
{
    public GameObject GetTile()
    {
        return gameObject;
    }
}
