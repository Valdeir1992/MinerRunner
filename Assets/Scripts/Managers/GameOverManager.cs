using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    public void Start()
    {
        // Pausar o jogo se necessario
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Reiniciar o jogo
        Time.timeScale = 1f; 

        // Recarregar a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
