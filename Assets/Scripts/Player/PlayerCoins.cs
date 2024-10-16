using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins:MonoBehaviour
{
    private int money;


    private void Awake()
    {
        PlayerPrefs.SetInt("coins", 0); // Valor inicial é 0
    }

    public void AddCoin(int coinValue)
    {
        money = PlayerPrefs.GetInt("coins"); // Define o valor de "money" como o de "coins"
        PlayerPrefs.SetInt("coins", money += coinValue); // Define novo valor de "coins"
        PlayerPrefs.Save(); // Salva o novo valor

    }
}
