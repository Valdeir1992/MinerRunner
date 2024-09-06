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

    [field: Header("UI Button SFX")]
    [field: SerializeField] public EventReference buttonSFX { get; private set; }

    [field: Header("UI Background")]
    [field: SerializeField] public EventReference uiBackground { get; private set; }

    public static FMODEvents instance { get; private set; }
    private void Awake ()
    { 
        if (instance == null)
        {
          Debug.LogError("Mais de um FMODEvents em cena");
        }

        instance = this; 
    }
}
