using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    [SerializeField] private GameObject enemyPrefab;

    private void SpawnEnemy()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        
        Instantiate(enemyPrefab, point.position, point.rotation);
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnEnemy();
        }
    }
}
