using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerWave = 3;
    public float timeBetweenWaves = 5f;

    private int waveIndex = 0;
    private bool spawning = false;

    void Update()
    {
        if (!spawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        spawning = true;
        waveIndex++;

        for (int i = 0; i < enemiesPerWave + waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }

        spawning = false;
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return;
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, sp.position, sp.rotation);
    }
}
