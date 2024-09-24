using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    private List<EventInstance> eventInstances;
    public static AudioManager instance { get=>_instance; }
    private EventInstance _eventInstance;
    private void Awake()
    {
        if(_instance == null)
        { 
            _instance = this;
        }
        else if(_instance != this)
        {
            Debug.LogError("Mais de um Audio Manager na cena");
            Destroy(gameObject);
        } 

        eventInstances = new List<EventInstance>();
    }

    private void Start()
    {
        StartMusic(FMODEvents.Instance.gameBackground);
    }
    public void PlayOneShot (EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void StartMusic (EventReference eventReference)
    {
        _eventInstance = CreateEventInstance(eventReference);
        _eventInstance.start();
    }
    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
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
