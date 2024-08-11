using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenuUI; // Refer�ncia ao menu de pausa
    private bool isPaused = false; // Estado de pausa

    void Start()
    {
        pauseMenuUI.SetActive(false); // Oculta o menu de pausa no in�cio
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
