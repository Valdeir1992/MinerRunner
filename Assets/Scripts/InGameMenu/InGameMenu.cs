using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] 
    private InGameConfigMenu _startGameMenuPrefab;
    private GameObject pauseMenuUI;

    private bool isPaused = false; // Estado de pausa

    public void ConfigClicked()
    {
        Time.timeScale = 0f; // Pausa o jogo
        InstantiateAsync(_startGameMenuPrefab); // Chama prefab do menu de configuracoes
    }

    public void PauseClicked()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa o jogo
            pauseMenuUI.SetActive(true); // Mostra o menu de pausa
        }
        else
        {
            Time.timeScale = 1f; // Retoma o jogo
            pauseMenuUI.SetActive(false); // Oculta o menu de pausa
        }
    }
}
