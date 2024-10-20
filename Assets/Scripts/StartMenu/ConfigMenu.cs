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
    private Slider uxmlMusicSlider;
    private Slider uxmlSfxSlider;

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
        uxmlMusicSlider.value = PlayerPrefs.GetFloat("userMusicVolume");

        uxmlSfxSlider.RegisterCallback<ChangeEvent<float>>(SetSfxSettings);
        uxmlSfxSlider.value = PlayerPrefs.GetFloat("userSfxVolume");

        SoundBus.instance.SetMusic();
    }

    private void SetMusicSettings(ChangeEvent<float> evt) 
    {
        uxmlMusicSlider.value = evt.newValue;
        SoundBus.instance.musicVolume = evt.newValue;
        PlayerPrefs.SetFloat("userMusicVolume", evt.newValue);
        PlayerPrefs.Save();

    }

    private void SetSfxSettings(ChangeEvent<float> evt)
    {
        uxmlSfxSlider.value = evt.newValue;
        SoundBus.instance.sfxVolume = evt.newValue;
        PlayerPrefs.SetFloat("userSfxVolume", evt.newValue);
        PlayerPrefs.Save();
    }

    private void VoltarClicked ()
    {
        Time.timeScale = 1f; // Despausa o jogo caso estivesse pausado
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX, this.transform.position); // Som do botao

        GameObject.Destroy(gameObject);
    }

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
