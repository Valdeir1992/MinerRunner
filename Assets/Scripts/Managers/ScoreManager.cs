using UnityEngine;
using TMPro; // Uso do TextMeshPro para UI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance
    public TextMeshProUGUI scoreText; // Componente UI para mostrar a pontuação

    private int score = 0; // Variável privada para armazenar a pontuação

    // Propriedade pública para acessar a pontuação
    public int CurrentScore
    {
        get { return score; }
        private set
        {
            score = value;
            UpdateScoreText(); // Atualiza o texto da UI sempre que a pontuação mudar
        }
    }

    private void Awake()
    {
        // Singleton setup
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Manter durante a troca de cenas

        // Verificação de segurança
        if (scoreText == null)
        {
            Debug.LogError("ScoreManager: scoreText não está atribuído no inspetor!");
        }
    }

    public void AddScore(int points)
    {
        CurrentScore += points; // Atualiza pontuação através da propriedade
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + CurrentScore; // Usa a propriedade CurrentScore
        }
    }
}
