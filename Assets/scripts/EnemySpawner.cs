using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public float spawnInterval = 3f;

    float timer = 0;

    void Update()
    {
        timer+=Time.deltaTime;
        if(timer >=spawnInterval)
        {
            timer=0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], transform);
    }
}
