using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Audio;
using System;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using static UnityEditor.Recorder.OutputPath;

public class ConfigMenu : MonoBehaviour
{
    private Slider sliderMusica;
    private Slider sliderSFX;

    public static ConfigMenu instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("BT_Voltar").clicked += VoltarClicked;     

    }

    private void VoltarClicked ()
    {
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX);
        SceneManager.LoadSceneAsync(0);
    }

    public void SetVolume (float volume)
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        sliderMusica = root.Q<Slider>("VolumeMusica");
        sliderMusica.value = volume;

        sliderSFX = root.Q<Slider>("VolumeSFX");

        Debug.Log(volume);
    }



}
