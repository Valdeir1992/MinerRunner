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
        //Som do botao
        AudioManager.instance.PlayOneShot(FMODEvents.Instance.playSFX, this.transform.position);

        // Reiniciar o jogo
        Time.timeScale = 1f; 

        // Recarregar a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        //Som do botao
        AudioManager.instance.PlayOneShot(FMODEvents.Instance.playSFX, this.transform.position);

        // Reiniciar o jogo
        Time.timeScale = 1f;

        // Recarregar a cena atual
        SceneManager.LoadScene(0);
    }
}
