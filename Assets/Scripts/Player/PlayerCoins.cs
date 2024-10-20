using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins:MonoBehaviour
{
    private int money = 0;


    private void Awake()
    {
        PlayerPrefs.SetInt("coins", money); // Valor inicial é o mesmo de "money"
    }

    public void AddCoin(int coinValue)
    {
        money = PlayerPrefs.GetInt("coins"); // Define o valor de "money" como o de "coins"
        PlayerPrefs.SetInt("coins", money += coinValue); // Define novo valor de "coins"
        PlayerPrefs.Save(); // Salva o novo valor

        CoinsText.Instance.ShowCoins();

    }
}
