using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("BT_Config").clicked += () => SceneManager.LoadSceneAsync(1);
        root.Q<Button>("BT_Play").clicked += () => SceneManager.LoadSceneAsync(2);
       
    }
}
