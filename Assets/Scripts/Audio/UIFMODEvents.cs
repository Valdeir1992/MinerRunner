using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFMODEvents : MonoBehaviour
{
    [field: Header("UI Button SFX")]
    [field: SerializeField] public EventReference buttonSFX { get; private set; }

    [field: Header("UI Voltar SFX")]
    [field: SerializeField] public EventReference voltarSFX { get; private set; }

    [field: Header("UI Play SFX")]
    [field: SerializeField] public EventReference playSFX { get; private set; }

    [field: Header("UI Background")]
    [field: SerializeField] public EventReference uiBackground { get; private set; }

    public static UIFMODEvents instance { get => _instance; }
    private static UIFMODEvents _instance;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.LogError("Mais de um UI Audio Manager em cena");
            Destroy(gameObject);
        }

    }
}
