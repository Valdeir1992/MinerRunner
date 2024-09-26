using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{
    [SerializeField] private ConfigMenu _startMenuPrefab;

    private void Awake()
    {
        Time.timeScale = 1f; // Despausa o jogo caso estivesse pausado
    }
    private void Start()
    {
             
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("BT_Config").clicked += async () =>
        {
            InstantiateAsync(_startMenuPrefab);
            UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.buttonSFX, this.transform.position); //Tocar som do botao
        };

        root.Q<Button>("BT_Play").clicked += () => 
        {
            UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.playSFX, this.transform.position); //Tocar som do botao
            SceneManager.LoadSceneAsync(1);

            FindAnyObjectByType<FadeController>().FadeOut(()=> {
                SceneManager.LoadSceneAsync(1);
            });

        };
        FindAnyObjectByType<FadeController>().FadeIn(null);

    }





} 
