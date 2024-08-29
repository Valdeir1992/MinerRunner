using System;
using System.Collections;
using UnityEngine;

public class MapSection : MonoBehaviour
{
     public Action OnRealeaser; 
     [SerializeField] private MeshRenderer _render;

    private void OnBecameInvisible(){
        Release();
    }
 
    private void Release(){
        OnRealeaser?.Invoke(); 
        OnRealeaser = null;
    }
}
