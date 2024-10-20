using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundBus : MonoBehaviour
{
    public static SoundBus instance { get => _instance; }
    private static SoundBus _instance;

    FMOD.Studio.Bus musicBus;
    FMOD.Studio.Bus sfxBus;

    [SerializeField][Range(0, 1)] public float musicVolume;
    [SerializeField][Range(0, 1)] public float sfxVolume;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.LogError("Mais de um Audio Manager na cena");
            Destroy(gameObject);
        }

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

