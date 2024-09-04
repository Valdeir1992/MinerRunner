using UnityEngine;
using TMPro; // Uso do TextMeshPro para UI

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreGameplayView; 
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
        
        if (scoreText == null)
        {
            Debug.LogError("ScoreManager: scoreText n�o est� atribu�do no inspetor!");
        }
    } 

    public void AddScore(int points)
    {
        CurrentScore += points; // Atualiza pontua��o atrav�s da propriedade
        _scoreGameplayView.SetText($"Score: {CurrentScore:D6}");
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
