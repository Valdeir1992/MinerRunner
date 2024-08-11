using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Referência ao painel de Game Over

    void Start()
    {
        gameOverPanel.SetActive(false); // Oculta o painel de Game Over no início
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true); // Mostra o painel de Game Over
        Time.timeScale = 0f; // Pausa o jogo
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Retoma o tempo do jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia a cena atual
    }
}
