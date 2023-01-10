using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public float spawnRate;
    private float lastSpawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time < lastSpawnTime + spawnRate)
            return;

        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        lastSpawnTime = Time.time;
    }
}
