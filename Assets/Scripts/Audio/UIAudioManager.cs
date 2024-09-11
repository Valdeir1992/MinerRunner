using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class UIAudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;
    public static UIAudioManager instance { get; private set; }
    private EventInstance _eventInstance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mais de um Audio Manager na cena");
        };

        instance = this;

        eventInstances = new List<EventInstance>();
    }

    private void Start()
    {
        StartMusic(UIFMODEvents.instance.uiBackground);
    }

    public void PlayOneShot(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound);
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
