using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform obstacleContainer;
    [SerializeField] private float spawnWidth = 4f;
    [SerializeField] private float obstacleSpawnInterval = 3f;
    [SerializeField] private float obstacleSpawnMinInterval = .1f;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    public void DecreaseSpawnInterval(float amount)
    {
        obstacleSpawnInterval -= amount;
        
        if (obstacleSpawnInterval - amount <= obstacleSpawnMinInterval)
        {
            obstacleSpawnInterval = obstacleSpawnMinInterval;
        }
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y,
                transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnInterval);
            Instantiate(obstacle, spawnPosition, Random.rotation, obstacleContainer);
        }
    }
}
