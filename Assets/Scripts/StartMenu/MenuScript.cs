<<<<<<< HEAD:Assets/Scripts/StartMenu/MenuScript.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private StartMenuConfiguration _startMenuPrefab;
    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("BT_Config").clicked += async () => InstantiateAsync(_startMenuPrefab);
        root.Q<Button>("BT_Play").clicked += () => SceneManager.LoadSceneAsync(2);
       
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private ConfigMenu _startMenuPrefab;
    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("BT_Config").clicked += async () => InstantiateAsync(_startMenuPrefab); //NÃO FUNCIONA 
        root.Q<Button>("BT_Play").clicked += () => SceneManager.LoadSceneAsync(1);
       
    }
}
>>>>>>> ui:Assets/Scripts/MenuScript.cs
