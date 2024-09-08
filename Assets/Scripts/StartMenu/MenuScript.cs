using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static UnityEditor.Recorder.OutputPath;
using FMOD.Studio;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private ConfigMenu _startMenuPrefab;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("BT_Config").clicked += ConfigClicked;
        root.Q<Button>("BT_Play").clicked += PlayClicked;

    }

    private void ConfigClicked ()
    {
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.buttonSFX, this.transform.position);
        InstantiateAsync(_startMenuPrefab);
    }

    private void PlayClicked ()
    {
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.playSFX, this.transform.position);
        SceneManager.LoadSceneAsync(1);
    }

    } 
