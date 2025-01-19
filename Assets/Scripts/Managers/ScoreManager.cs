using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameManager gameManager;

    private int _score;
    public void UpdateScore(int amount)
    {
        if (gameManager.IsGameOver) return;
        
        _score += amount;
        scoreText.text = $"Score: {_score}";
    }
}
