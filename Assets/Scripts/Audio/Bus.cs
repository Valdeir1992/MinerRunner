using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bus : MonoBehaviour
{
    public static Bus instance;

    FMOD.Studio.Bus musicBus;
    FMOD.Studio.Bus sfxBus;

    [SerializeField][Range(0, 1)] private float musicVolume;
    [SerializeField][Range(0, 1)] private float sfxVolume;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetMusic();
    }

    private void Update()
    {
        musicBus.setVolume(musicVolume);

        sfxBus.setVolume(sfxVolume);
    }


    private void SetMusic()
    {
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/MusicBus");
        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/SFXBus");

        //Para o jogo iniciar com volume
        musicVolume = 0.4f;
        sfxVolume = 1.0f;

    }
}

