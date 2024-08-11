using UnityEngine;
using TMPro; // Uso do TextMeshPro para UI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance
    public TextMeshProUGUI scoreText; // Componente UI para mostrar a pontua��o

    private int score = 0; // Vari�vel privada para armazenar a pontua��o

    // Propriedade p�blica para acessar a pontua��o
    public int CurrentScore
    {
        get { return score; }
        private set
        {
            score = value;
            UpdateScoreText(); // Atualiza o texto da UI sempre que a pontua��o mudar
        }
    }

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Verifica��o de seguran�a
        if (scoreText == null)
        {
            Debug.LogError("ScoreManager: scoreText n�o est� atribu�do no inspetor!");
        }
    }

    public void AddScore(int points)
    {
        CurrentScore += points; // Atualiza pontua��o atrav�s da propriedade
    }

    public void ResetScore()
    {
        CurrentScore = 0; // Reinicia a pontua��o
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + CurrentScore; // Usa a propriedade CurrentScore
        }
    }
}
