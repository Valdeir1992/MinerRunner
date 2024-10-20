using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{
    [SerializeField] ConfigMenu _startMenuPrefab;

    private void Awake()
    {
        Time.timeScale = 1f; // Despausa o jogo caso estivesse pausado
    }
    private void Start()
    {
        FindAnyObjectByType<FadeController>().FadeIn(null);

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("BT_Config").clicked += () => ConfigClicked();

        root.Q<Button>("BT_Play").clicked += () => PLayClicked(); 
       

    }

    private void ConfigClicked()
    {
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.buttonSFX, this.transform.position); //Tocar som do botao
        Instantiate(_startMenuPrefab);
    }

    private void PLayClicked()
    {
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.playSFX, this.transform.position); //Tocar som do botao

        FindAnyObjectByType<FadeController>().FadeOut(() => 
        {
            SceneManager.LoadSceneAsync(1);
        });
    }
} 
