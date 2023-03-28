using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner2 : MonoBehaviour
{
    public BulletSpawnData[] spawnDatas;
    public int index = 0;
    public bool isSequenceRandom;
    public bool spawnAutomatically;
    BulletSpawnData GetSpawnData()
    {
        return spawnDatas[index];
    }
    float timer;

    float[] rotations;
    void Start()
    {
        timer = GetSpawnData().cooldown;

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnAutomatically)
        {
            if (timer <= 0)
            {
                SpawnBullets();
                timer = GetSpawnData().cooldown;
                if (isSequenceRandom)
                {
                    index = Random.Range(0, spawnDatas.Length);
                }
                else
                {
                    index += 1;
                    if (index >= spawnDatas.Length) index = 0;
                }
                rotations = new float[GetSpawnData().numberOfBullets];

            }
            timer -= Time.deltaTime;
        }
    }

    // Select a random rotation from min to max for each bullet
    public float[] RandomRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            rotations[i] = Random.Range(GetSpawnData().minRotation, GetSpawnData().maxRotation);
        }
        return rotations;

    }

    // This will set random rotations evenly distributed between the min and max Rotation.
    public float[] DistributedRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            var fraction = (float)i / ((float)GetSpawnData().numberOfBullets - 1);
            var difference = GetSpawnData().maxRotation - GetSpawnData().minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + GetSpawnData().minRotation; // We add minRotation to undo Difference
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }
    public GameObject[] SpawnBullets()
    {
        rotations = new float[GetSpawnData().numberOfBullets];
        if (GetSpawnData().isRandom)
        {
            RandomRotations();
        }
        else
        {
            DistributedRotations();
        }

        // Spawn Bullets
        GameObject[] spawnedBullets = new GameObject[GetSpawnData().numberOfBullets];
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            spawnedBullets[i] = BulletManager.GetBulletFromPool();
            if (spawnedBullets[i] == null)
            {
                spawnedBullets[i] = Instantiate(GetSpawnData().bulletResource, transform.position, transform.rotation);
            }
            else
            {
                spawnedBullets[i].transform.SetParent(transform);
                spawnedBullets[i].transform.localPosition = Vector3.zero;
            }
            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = GetSpawnData().bulletSpeed;
            b.velocity = GetSpawnData().bulletVelocity;
            if (!GetSpawnData().isParent) spawnedBullets[i].transform.SetParent(null);
        }
        return spawnedBullets;
    }
}
