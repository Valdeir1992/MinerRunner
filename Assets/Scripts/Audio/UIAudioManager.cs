using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class UIAudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;
    public static UIAudioManager instance { get => _instance; }
    private static UIAudioManager _instance;

    private EventInstance _eventInstance;

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

       eventInstances = new List<EventInstance>();


        SoundBus.instance.musicVolume = PlayerPrefs.GetFloat("userMusicVolume");
        SoundBus.instance.sfxVolume = PlayerPrefs.GetFloat("userSfxVolume");
    }

    private void Start()
    {
          StartMusic(UIFMODEvents.instance.uiBackground); //Tocar musica
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void StartMusic(EventReference eventReference)
    {
        _eventInstance = CreateEventInstance(eventReference);
        _eventInstance.start();
    }

    private void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }

}
