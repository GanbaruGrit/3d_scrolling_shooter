using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimedShot : MonoBehaviour
{
    public Transform targetTransform;
    public Enemy enemyScript;

    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bulletPrefab1;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private float timeBeforeFirstBurst;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float timeBetweenSets;

    private bool isShooting;

    void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
        enemyScript = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeFirstBurst -= Time.deltaTime;

        if (timeBeforeFirstBurst <= 0 && enemyScript.isAlive)
        {
            StartBurst();
        }
    }

    private void StartBurst()
    {
        if (isShooting) return;
        //audioSrc.Play();
        isShooting = true;
        Invoke("ResetShoot", timeBetweenBursts);

        Shoot();
    }

    public void Shoot()
    {
        {
            GameObject bullet = Instantiate(bulletPrefab1);
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.LookAt(targetTransform);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;
            //Invoke("DestroySelf", 2f);
        }
    }

    private void ResetShoot()
    {
        isShooting = false;
    }
}
