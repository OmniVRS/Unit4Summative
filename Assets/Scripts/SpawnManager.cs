using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 10f;
    private int waveCount = 1;
    private int enemyCount;
    private int powerupCount;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPoint(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCount = FindObjectsByType<EnemyControl>(0).Length;
        powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;
        if (enemyCount == 0)
        {
            if (powerupCount == 0)
            {
                Instantiate(powerupPrefab, GenerateSpawnPoint(), powerupPrefab.transform.rotation);
            }
            waveCount++;
            SpawnEnemyWave(waveCount);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }

    private Vector2 GenerateSpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        Vector2 randomPos = new Vector2(spawnPosX, 6);
        return randomPos;
    }
}
