using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    public Action OnRealease;
    public Action OnCollect;  
    private void OnBecameInvisible()
    {
        Release();
    } 
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
            AudioManager.instance.PlayOneShot(FMODEvents.instance.coinCollectSFX, this.transform.position); //testar
        }
        Release();
    }
    private void Collect(){
        OnCollect?.Invoke();
        OnCollect = null;
    }
    private void Release(){
        OnRealease?.Invoke();
        OnRealease = null;
    }
}
