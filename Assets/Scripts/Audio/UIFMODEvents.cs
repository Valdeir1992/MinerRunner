using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFMODEvents : MonoBehaviour
{
    [field: Header("UI Button SFX")]
    [field: SerializeField] public EventReference buttonSFX { get; private set; } //private?

    [field: Header("UI Voltar SFX")]
    [field: SerializeField] public EventReference voltarSFX { get; private set; }

    [field: Header("UI Play SFX")]
    [field: SerializeField] public EventReference playSFX { get; private set; }

    [field: Header("UI Background")]
    [field: SerializeField] public EventReference uiBackground { get; private set; }

    public static UIFMODEvents instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            Debug.LogError("Mais de um FMODEvents em cena");
        }

        instance = this;
    }
}
