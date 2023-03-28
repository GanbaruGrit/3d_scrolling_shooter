using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyShotData", order = 1)]
public class EnemyShotData : ScriptableObject
{
    /*
    public string prefabName;
    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;

    [Header("New Shot Settings")]
    [SerializeField] public string burstType;
    [SerializeField] public int numOfShots = 4;
    [SerializeField] public float timeBetweenShots = 2f;
    [SerializeField] public float timeBeforeFirstBurst;
    [SerializeField] public float timeBetweenBursts = 2f;
    public float betweenBurstsTimer;
    public bool canShoot = true;

    [SerializeField] public float xAngle, yAngle, zAngle;
    */

    [SerializeField] public float bulletSpeed = 8f;
    [SerializeField] public int bulletDamage = 1;
}
