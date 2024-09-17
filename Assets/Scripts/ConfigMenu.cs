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
    public static ConfigMenu instance;

    //Controle de volume
    [Range(0, 1)] private float musicVolume;
    
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        //Button
        root.Q<Button>("BT_Voltar").clicked += VoltarClicked;

       //SetFillSlider(slider);
    }

    private void Update()
    {
        SetVolume();
    }
    private void VoltarClicked ()
    {
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX, this.transform.position);
        SceneManager.LoadSceneAsync(0);
    }

    private void SetVolume()
    {
        var uxmlSliderMusica = GetComponent<UIDocument>().rootVisualElement.Q<Slider>("VolumeMusica");
        var uxmlSliderSfx = GetComponent<UIDocument>().rootVisualElement.Q<Slider>("VolumeSFX");
        Bus.instance.musicVolume = uxmlSliderMusica.value;
        Bus.instance.sfxVolume = uxmlSliderSfx.value;
        Bus.instance.SetMusic();
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
