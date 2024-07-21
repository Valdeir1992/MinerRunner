using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConfigMenu : MonoBehaviour
{
    public Slider fill;
    
    //Botão (NÃO ESTÁ FUNCIONANDO - "objeto instantiate é nulo")
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var returnButton = root.Q<Button>("BT_Voltar");
        returnButton.clicked += () => Destroy(gameObject);
    }

    //Slider e Fill Bar (NÃO ESTÁ FUNCIONANDO)

    private VisualElement m_root;
    private VisualElement m_slider;
    private VisualElement m_dragger;
    private VisualElement m_bar;

    void Start()
    {
        m_root = GetComponent<UIDocument>().rootVisualElement;
        m_slider = m_root.Q<VisualElement>("VolumeMusica");
        m_dragger = m_root.Q<VisualElement>("unity-dragger");

        AddElements();
     
    }

    void AddElements()
    {
        m_bar = new VisualElement();
        m_dragger.Add(m_bar);
        m_bar.name = "Bar";
        m_bar.AddToClassList("bar");
    }

}
