using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float timeExtension = 5f;
    [SerializeField] private float obstacleDecreaseTime = 0.2f;
    
    private GameManager _gameManager;
    private ObstacleSpawner _obstacleSpawner;

    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.AddTime(timeExtension);
            _obstacleSpawner.DecreaseSpawnInterval(obstacleDecreaseTime);
        }
    }
}
