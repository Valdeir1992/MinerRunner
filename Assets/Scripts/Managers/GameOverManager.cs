using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

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
        // Pausar o jogo se necessário
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Reiniciar o jogo
        Time.timeScale = 1f;

        // Reiniciar a pontuação
        if (ScoreManager.Instance != null)
        {
            Debug.Log("Reset score chamado no Game Over Manager...");
            ScoreManager.Instance.ResetScore();
        }

        // Recarregar a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
