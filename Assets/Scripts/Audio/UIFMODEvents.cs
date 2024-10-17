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

    private static UIFMODEvents _instance;
    public static UIFMODEvents instance { get => _instance; }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
