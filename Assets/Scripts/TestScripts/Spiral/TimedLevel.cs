using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// WHERE WE WILL MANUALLY CONTROL THE BULLET SPAWNER
public class TimedLevel : MonoBehaviour
{
    public BulletSpawner2 bulletSpawner;
    bool[] tasks = new bool[100];
    private void Start()
    {
        Time.fixedDeltaTime = 0.001f;
    }
    private void FixedUpdate()
    {
        if (TimeManager.ifTimeIs(3f, ref tasks[0]))
        {
            bulletSpawner.index = 0;
            bulletSpawner.SpawnBullets();
        }
        if (TimeManager.ifTimeIs(0.5f, ref tasks[1]))
        {
            bulletSpawner.index = 1;
            bulletSpawner.SpawnBullets();
        }
        if (TimeManager.ifTimeIs(1f, ref tasks[2]))
        {
            bulletSpawner.index = 1;
            bulletSpawner.SpawnBullets();
        }
        if (TimeManager.ifTimeIs(2f, ref tasks[3]))
        {
            bulletSpawner.index = 1;
            bulletSpawner.SpawnBullets();
        }
    }
}