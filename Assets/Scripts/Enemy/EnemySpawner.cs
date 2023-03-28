using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] int numEnemies;
    [SerializeField] float timeBetweenSpawns = .5f;
    [SerializeField] bool menuMode = false;

    void SpawnLoop()
    {
        if (numEnemies > 0)
        {
            Invoke("SpawnEnemy", timeBetweenSpawns);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = spawnPoint.position;
        numEnemies--;
        SpawnLoop();
    }

    private void OnTriggerEnter(Collider other)
    {
        SpawnLoop();
        print("spawnloop hit");
    }
}
