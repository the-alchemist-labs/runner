using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int _score;
    public void UpdateScore(int amount)
    {
        _score += amount;
        scoreText.text = $"Score: {_score}";
    }
}
