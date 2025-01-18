using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private CameraController cameraController;

    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private Transform chunkParent;

    [Header("Level Settings")] [SerializeField]
    private int startingChunksAmount = 12;

    [Tooltip("Reflects size of prefab")] [SerializeField]
    private float chunkLength = 10f;

    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float minMoveSpeed = 2f;
    [SerializeField] private float maxMoveSpeed = 20f;
    [SerializeField] private float minGravityZ = -22f;
    [SerializeField] private float maxGravityZ = -2f;

    List<GameObject> _chunks = new List<GameObject>();

    void Start()
    {
        SpawnStartingChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    public void UpdateChunkMoveSpeed(float speedModifier)
    {
        float newMoveSpeed = Mathf.Clamp(moveSpeed + speedModifier, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;
            
            float newGravityZ = Mathf.Clamp(Physics.gravity.z - speedModifier, minGravityZ, maxGravityZ);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
            
            cameraController.ChangeCameraFOV(speedModifier);
        }
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        _chunks.Add(newChunk);
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (_chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = _chunks[_chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < _chunks.Count; i++)
        {
            GameObject chunk = _chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                _chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}