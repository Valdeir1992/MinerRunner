using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Collectible:MonoBehaviour{
    public Action OnRelease;
    [SerializeField] private PowerUp _effect;
 
    private void OnBecameInvisible()
    {
        Release();
    }
    private void OnTriggerEnter(Collider collider){
        if(collider.TryGetComponent(out PlayerMediator mediator)){
            mediator.Coroutine_PowerUPs(_effect);
            Release();
        }
    }
    private void Release(){
        OnRelease?.Invoke();
        OnRelease = null;
    }
}
