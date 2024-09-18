using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Audio;
using System;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using static UnityEditor.Recorder.OutputPath;
using UnityEditor.UIElements;

public class ConfigMenu : MonoBehaviour
{
    public static ConfigMenu instance;

    private Slider uxmlMusicSlider;
    private Slider uxmlSfxSlider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        //Button
        root.Q<Button>("BT_Voltar").clicked += VoltarClicked;

        //Slider
        uxmlMusicSlider = GetComponent<UIDocument>().rootVisualElement.Q<Slider>("VolumeMusica");
        uxmlSfxSlider = GetComponent<UIDocument>().rootVisualElement.Q<Slider>("VolumeSFX");
    }

    private void Update()
    {
        uxmlMusicSlider.RegisterCallback<ChangeEvent<float>>(SetMusicSettings);
        uxmlSfxSlider.RegisterCallback<ChangeEvent<float>>(SetSfxSettings);
    }

    private void SetMusicSettings(ChangeEvent<float> evt) 
    {
        uxmlMusicSlider.value = evt.newValue;
        Bus.instance.musicVolume = evt.newValue;

    }

    private void SetSfxSettings(ChangeEvent<float> evt)
    {
        uxmlSfxSlider.value = evt.newValue;
        Bus.instance.sfxVolume = evt.newValue;
    }

    private void VoltarClicked ()
    {
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX, this.transform.position);
        SceneManager.LoadSceneAsync(0);

    }

    /// <summary>
    /// Adicionar componente de arrastar visualmente no slider
    /// </summary>
    /// <param name="volume"></param>
    private void SetFillSlider(Slider slider)
    {
        var container = new VisualElement();
        container.name = "Visual fill";
        container.style.position = Position.Absolute;
        var bar = new VisualElement();
        container.Add(bar);
        slider.Add(container);
        slider.RegisterValueChangedCallback<float>(ctx => 
        {
            bar.style.width = Length.Percent(ctx.newValue);
            Debug.Log(ctx.newValue);
        });
    }
  


}
