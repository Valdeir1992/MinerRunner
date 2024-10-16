using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private InGameConfigMenu _startGameMenuPrefab;
    public void ConfigClicked()
    {
        Time.timeScale = 0f; // Pausa o jogo
        InstantiateAsync(_startGameMenuPrefab); // Chama prefab do menu de configuracoes
    }
}
