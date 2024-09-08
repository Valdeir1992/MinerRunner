using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Audio;
using System;
using UnityEngine.SceneManagement;
using FMOD.Studio;

public class ConfigMenu : MonoBehaviour
{
    //para conseguir instanciar ele no Menu Principal
    public static ConfigMenu instance; 
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var slider = root.Q<Slider>();
        SetFillSlider(slider);

        root.Q<Button>("BT_Voltar").clicked += VoltarClicked;
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
    public void SetVolume (float volume)
    {
        Debug.Log(volume);
    }



}
