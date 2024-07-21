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
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("BT_Config").clicked += async () => InstantiateAsync(_startMenuPrefab);
        root.Q<Button>("BT_Play").clicked += () => SceneManager.LoadSceneAsync(1);
       
    }
}
