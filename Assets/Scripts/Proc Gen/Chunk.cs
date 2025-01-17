using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float coinSeparationLength = 2f;
    [SerializeField] private float appleSpawnChance = .3f;
    [SerializeField] private float coinSpawnChance = .5f;
    [SerializeField] private int maxCoinsToSpawn = 5;
    
    [SerializeField] private float[] lanes = { -2.5f, 0f, 2.5f };

    private readonly List<int> _availableLanes = new() { 0, 1, 2 };

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    private void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (_availableLanes.Count <= 0) break;

            var selectedLane = SelectLane();

            Vector3 fencePosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, fencePosition, Quaternion.identity, transform);
        }
    }

    private void SpawnApple()
    {
        if (Random.value > appleSpawnChance || _availableLanes.Count <= 0) return;

        var selectedLane = SelectLane();

        Vector3 fencePosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, fencePosition, Quaternion.identity, transform);
    }
    
    private void SpawnCoins()
    {
        if (Random.value > coinSpawnChance || _availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();
        int coinsToSpawn = Random.Range(0, maxCoinsToSpawn + 1);

        float zPosStart = transform.position.z + (coinSeparationLength * 2);
        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPosZ = zPosStart - (i * coinSeparationLength);
            Vector3 fencePosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPosZ);
            Instantiate(coinPrefab, fencePosition, Quaternion.identity, transform);
        }
    }
    
    private int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, _availableLanes.Count);
        int selectedLane = _availableLanes[randomLaneIndex];
        _availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

}