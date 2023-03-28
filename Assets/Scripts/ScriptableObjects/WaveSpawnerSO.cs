using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerSO : MonoBehaviour
{
    public Wave[] waves;
    private Wave currentWave;
    [SerializeField] private Transform[] spawnPoints;

    //public enum SpawnState { SPAWNING, WAITING, COUNTING };
    //private SpawnState state = SpawnState.COUNTING;

    private float timeBtwnSpawns;
    private int i = 0;
    private bool stopSpawning = false;

    void Awake()
    {
        currentWave = waves[i];
        timeBtwnSpawns = currentWave.TimeBeforeThisWave;
    }

    void Update()
    {
        if (stopSpawning)
        {
            return;
        }

        if (Time.time >= timeBtwnSpawns)
        {
            SpawnWave();
            IncWave();

            timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, spawnPoints.Length);

            Instantiate(currentWave.EnemiesInWave[num], spawnPoints[num2].position, spawnPoints[num2].rotation);
        }
    }

    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }
}
