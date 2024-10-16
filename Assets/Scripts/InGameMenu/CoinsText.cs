using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;

    private void Start() //Começa mostrando o valor atual das moedas
    {
        ShowCoins();
    }

    public void ShowCoins()
    {
        var coinInt = PlayerPrefs.GetInt("coins");
        coinsText.text = "Coins: " + coinInt.ToString();
    }
}
