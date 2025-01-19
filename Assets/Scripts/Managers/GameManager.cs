using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private float gameTime;

    private bool _isGameOver;
    public bool IsGameOver => _isGameOver;
    
    private float _timeLeft;

    private void Start()
    {
        gameOverText.SetActive(false);
        _timeLeft = gameTime;
    }

    void Update()
    {

        if (_timeLeft < 0)
        {
            GameOver();
            return;
        }
        
        _timeLeft -= Time.deltaTime;
        timeText.text = (_timeLeft > 0) ?_timeLeft.ToString("00.00") : "00.00";
    }

    public void AddTime(float time)
    {
        _timeLeft += time;  
    }
    
    private void GameOver()
    {
        _isGameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}