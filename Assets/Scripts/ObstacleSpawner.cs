using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    private int _obstacleSpawnCount = 0;
    void Start()
    {
        while (_obstacleSpawnCount < 5)
        {
            _obstacleSpawnCount++;
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        }
    }
}
