using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bus : MonoBehaviour
{
    public static Bus instance;

    FMOD.Studio.Bus musicBus;
    FMOD.Studio.Bus sfxBus;

    [SerializeField][Range(0, 1)] public float musicVolume;
    [SerializeField][Range(0, 1)] public float sfxVolume;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/MusicBus");
        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/SFXBus");
    }

    public void SetMusic()
    {
        musicBus.setVolume(musicVolume);
        sfxBus.setVolume(sfxVolume);
    }
}

