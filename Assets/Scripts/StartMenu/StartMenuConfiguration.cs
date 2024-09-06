using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartMenuConfiguration : MonoBehaviour
{
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var returnButton = root.Q<Button>();
        returnButton.clicked += ReturnClicked;
    }

    private void ReturnClicked ()
    {
        Destroy(gameObject);
    }

}
