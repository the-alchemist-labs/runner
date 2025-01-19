using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float timeExtension = 5f;
    
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.AddTime(timeExtension);
        }
    }
}
