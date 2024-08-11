using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referência ao menu de pausa
    private bool isPaused = false; // Estado de pausa

    void Start()
    {
        pauseMenuUI.SetActive(false); // Oculta o menu de pausa no início
    }

    public void TogglePause()
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
