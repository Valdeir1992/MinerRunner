using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class UIBus : MonoBehaviour
{
    public static UIBus instance;

    FMOD.Studio.Bus uiMusicBus;
    FMOD.Studio.Bus uiSfxBus;

    [SerializeField][Range(0f, 1f)] private float uiMusicVolume;
    [SerializeField][Range(0f, 1f)] private float uiSfxVolume;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetUIMusic();   
    }

    private void Update()
    {
        uiMusicBus.setVolume(uiMusicVolume);
        uiSfxBus.setVolume(uiSfxVolume);
    }
    
    private void SetUIMusic ()
    {
        uiMusicBus = FMODUnity.RuntimeManager.GetBus("bus:/UIMuicBus");
        uiSfxBus = FMODUnity.RuntimeManager.GetBus("bus:/UISFXBus");
        
        //Para o jogo iniciar com volume
        uiMusicVolume = 1.0f;
        uiMusicVolume = 1.0f;

        //Pega o slider do config menu e iguala o valor a private float do volume
        //xxx = uiMusicVolume;
        //xxx = uiSfxVolume;

    }
}
