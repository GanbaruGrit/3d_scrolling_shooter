using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletSpawnData", order = 1)]
public class BulletSpawnData : ScriptableObject
{
    public GameObject bulletResource;
    public float minRotation;
    public float maxRotation;
    public int numberOfBullets;
    public bool isRandom;
    public bool isParent = true;
    public float cooldown;
    public float bulletSpeed;
    public Vector3 bulletVelocity;
}
