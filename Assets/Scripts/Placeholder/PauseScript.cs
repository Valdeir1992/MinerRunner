using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
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

    private void HomeClicked()
    {
        Time.timeScale = 1f; // Despausa o jogo caso estivesse pausado
        SceneManager.LoadSceneAsync(0);
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX, this.transform.position); // Som do botao
    }
}
