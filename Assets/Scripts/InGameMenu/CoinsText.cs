using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;

    public static CoinsText Instance { get => _instance; }
    private static CoinsText _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

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
