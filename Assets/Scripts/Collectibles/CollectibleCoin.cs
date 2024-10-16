using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    public Action OnRealease;
    public Action OnCollect;

    [SerializeField] PlayerCoins _playerCoins;


    private void OnBecameInvisible()
    {
        Release();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
            AudioManager.instance.PlayOneShot(FMODEvents.Instance.coinCollectSFX, this.transform.position);
        }
        Release();

        if (_playerCoins != null)
        {
            _playerCoins.AddCoin(1);
        }
        Debug.Log(PlayerPrefs.GetInt("coins"));
    }
    private void Collect()
    {
        OnCollect?.Invoke();
        OnCollect = null;
    }
    private void Release()
    {
        OnRealease?.Invoke();
        OnCollect = null;
        OnRealease = null;
    }
}