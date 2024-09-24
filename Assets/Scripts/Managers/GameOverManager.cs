using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        // Pausar o jogo se necess�rio
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        //Som do botao
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.playSFX, this.transform.position);

        // Reiniciar o jogo
        Time.timeScale = 1f; 

        // Recarregar a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
