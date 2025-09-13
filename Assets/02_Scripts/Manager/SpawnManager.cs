using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    //[SerializeField] private GameObject enemyPrefab;

    private const string GOBLIN_ADDR = "Goblin";
    private const string PLAYER_ADDR = "Warrior";
    
    private async void SpawnEnemy()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        
        // Instantiate(enemyPrefab, point.position, point.rotation);
        var enemy = await AddressableManager.Instance.LoadAssetAsync<GameObject>(GOBLIN_ADDR);
        Instantiate(enemy, point.position, point.rotation);
    }

    private async void SpawnPlayer()
    {
        GameObject player = await AddressableManager.Instance.LoadAssetAsync<GameObject>(PLAYER_ADDR);
        Instantiate(player, Vector3.zero, Quaternion.identity);
    }
    
    private IEnumerator Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }
        
        SpawnPlayer();
    }
    
}
