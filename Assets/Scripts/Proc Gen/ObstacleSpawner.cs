using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform obstacleContainer;
    [SerializeField] private float obstacleSpawnInterval = 1f;
    [SerializeField] private float spawnWidth = 4f;
    
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnInterval);
            Instantiate(obstacle, spawnPosition, Random.rotation, obstacleContainer);
        }
    }
}
