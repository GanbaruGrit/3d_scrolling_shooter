using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    [Header("References")]
    private EnemyBulletSpawner enemyBulletSpawner;
    public EnemyShotData enemyShotData;
    public Rigidbody rb;

    public GameObject hitSpark;
    [SerializeField] private AudioSource hitAudio;

    [Header("Targets")]
    public Transform firstTargetTransform;
    public Transform secondTargetTransform;
    public Transform finalTargetTransform;

    [SerializeField] public int damage = 1;
    [SerializeField] float lifetime = 8;
    private float velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyBulletSpawner = GetComponentInParent<EnemyBulletSpawner>();

        /*
        firstTargetTransform = enemyBulletSpawner.firstTargetTransform;
        secondTargetTransform = enemyBulletSpawner.secondTargetTransform;
        finalTargetTransform = enemyBulletSpawner.finalTargetTransform;
        */

        velocity = enemyShotData.bulletSpeed;

        Invoke("DestroySelf", lifetime); // destroys bullet after time
        
        transform.parent = null; // remove parent to avoid moving mid-air bullets
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, velocity);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
