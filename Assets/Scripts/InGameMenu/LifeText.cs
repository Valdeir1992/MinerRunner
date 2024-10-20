using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] private PlayerHealth playerHealth;


    private void Start() //Começa mostrando o valor atual da vida
    {
        ShowLife();
    }

    public void ShowLife()
    {
          lifeText.text = "Life: " + playerHealth.currentHealth.ToString();
    }
}
