using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Jump SFX")]
    [field: SerializeField] public EventReference jumpSFX { get; private set;}

    [field: Header("Coin Collect SFX")]
    [field: SerializeField] public EventReference coinCollectSFX { get; private set; }

    [field: Header("Mining Kart SFX")]
    [field: SerializeField] public EventReference miningKartSFX { get; private set; }

    [field: Header("Game Background")]
    [field: SerializeField] public EventReference gameBackground { get; private set; }

    public static FMODEvents _instance {get; private set;}
    public static FMODEvents Instance { get=>_instance;}
    private void Awake ()
    { 
        if (Instance == null)
        {
          _instance = this; 
        }else if(_instance != this){ 
          Debug.LogError("Mais de um FMODEvents em cena");
          Destroy(this);
        }
    }
}
