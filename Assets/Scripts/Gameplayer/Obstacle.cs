using System;
using UnityEngine;

public class Obstacle:MonoBehaviour
{
    public Action OnRealease;

    private void OnBecameInvisible()
    {
        Release();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out PlayerMediator player))
        {
            player.TakeDamage(3); //Mudei para 3 para facilitar os testes
        }
        Release();
    }
    private void Release(){
        OnRealease?.Invoke();
        OnRealease = null;
    }
}
