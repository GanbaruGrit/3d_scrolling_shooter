using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    [Header("Shot Prefabs")]
    [SerializeField] private GameObject bulletPrefab1;
    [SerializeField] private GameObject bulletPrefab2;
    [SerializeField] private GameObject bulletPrefab3;
    
    [Header("Firepoint Prefabs")]
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject firePoint2;
    [SerializeField] private GameObject firePoint3;

    [SerializeField] private float xAngle, yAngle, zAngle;
    [SerializeField] private float bulletSpeed;
    [SerializeField] public int bulletDamage = 1;

    public Transform targetTransform;
    public Transform staticTransform;
    public Enemy enemyScript;

    [Header("New Shot Settings")]
    [SerializeField] string burstType;
    [SerializeField] int numOfShots = 4;
    [SerializeField] float timeBetweenShots = 2f;
    [SerializeField] private float timeBeforeFirstBurst;
    [SerializeField] private float timeBetweenBursts = 2f;
    private float betweenBurstsTimer;
    private bool canShoot = true;
    public bool inRange = true;

    void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
        enemyScript = GetComponent<Enemy>();
    }

     
    void Update()
    {
        timeBeforeFirstBurst -= Time.deltaTime;
        betweenBurstsTimer -= Time.deltaTime;

        if (timeBeforeFirstBurst <= 0 && enemyScript.isAlive && inRange && betweenBurstsTimer <= 0 && canShoot)
        {
            StartCoroutine(StartBurst());
        }
    }

    public void ToggleInRange(bool toggle)
    {
        inRange = toggle;
    }

    IEnumerator StartBurst()
    {
        canShoot = false;
        for (int currentShot = 0; currentShot < numOfShots; currentShot++)
            {
                Shoot(burstType);
                yield return new WaitForSeconds(timeBetweenShots);
            }
        betweenBurstsTimer = timeBetweenBursts;
        canShoot = true;
    }

    public void Shoot(string _burstType)
    {

        if (burstType == "AimedSingle")
        {
            GameObject bullet = Instantiate(bulletPrefab1);
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.LookAt(targetTransform);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;
            //Invoke("DestroySelf", 2f);
        }

        else if (burstType == "AimedRapid")
        {
            GameObject bullet2 = Instantiate(bulletPrefab1, firePoint2.transform.position, firePoint2.transform.rotation);
            //bullet2.transform.LookAt(targetTransform);
            //bullet2.transform.Rotate(xAngle, 15, zAngle, Space.Self);
            Rigidbody bulletRb2 = bullet2.GetComponent<Rigidbody>();
            bulletRb2.velocity = bullet2.transform.TransformDirection(Vector3.forward) * bulletSpeed;

            GameObject bullet3 = Instantiate(bulletPrefab1, firePoint3.transform.position, firePoint3.transform.rotation);

            //bullet3.transform.LookAt(targetTransform);
            //bullet3.transform.Rotate(xAngle, -15, zAngle, Space.Self);
            Rigidbody bulletRb3 = bullet3.GetComponent<Rigidbody>();
            bulletRb3.velocity = bullet3.transform.TransformDirection(Vector3.forward) * bulletSpeed;

        }

        else if (burstType == "AimedThreeSpread")
        {
            GameObject bullet = Instantiate(bulletPrefab1);
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.LookAt(targetTransform);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;

            GameObject bullet2 = Instantiate(bulletPrefab1);
            bullet2.transform.position = firePoint2.transform.position;
            bullet2.transform.LookAt(targetTransform);
            bullet2.transform.Rotate(xAngle, 15, zAngle, Space.Self);
            Rigidbody bulletRb2 = bullet2.GetComponent<Rigidbody>();
            bulletRb2.velocity = bullet2.transform.forward * bulletSpeed;

            GameObject bullet3 = Instantiate(bulletPrefab1);
            bullet3.transform.position = firePoint3.transform.position;
            bullet3.transform.LookAt(targetTransform);
            bullet3.transform.Rotate(xAngle, -15, zAngle, Space.Self);
            Rigidbody bulletRb3 = bullet3.GetComponent<Rigidbody>();
            bulletRb3.velocity = bullet3.transform.forward * bulletSpeed;

        }

        else if (burstType == "AimedFiveSpread")
        {
            GameObject bullet = Instantiate(bulletPrefab1);
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.LookAt(targetTransform);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;

            GameObject bullet2 = Instantiate(bulletPrefab1);
            bullet2.transform.position = firePoint2.transform.position;
            bullet2.transform.LookAt(targetTransform);
            bullet2.transform.Rotate(xAngle, 15, zAngle, Space.Self);
            Rigidbody bulletRb2 = bullet2.GetComponent<Rigidbody>();
            bulletRb2.velocity = bullet2.transform.forward * bulletSpeed;

            GameObject bullet3 = Instantiate(bulletPrefab1);
            bullet3.transform.position = firePoint3.transform.position;
            bullet3.transform.LookAt(targetTransform);
            bullet3.transform.Rotate(xAngle, -15, zAngle, Space.Self);
            Rigidbody bulletRb3 = bullet3.GetComponent<Rigidbody>();
            bulletRb3.velocity = bullet3.transform.forward * bulletSpeed;

            GameObject bullet4 = Instantiate(bulletPrefab1);
            bullet4.transform.position = firePoint2.transform.position;
            bullet4.transform.LookAt(targetTransform);
            bullet4.transform.Rotate(xAngle, 30, zAngle, Space.Self);
            Rigidbody bulletRb4 = bullet4.GetComponent<Rigidbody>();
            bulletRb4.velocity = bullet4.transform.forward * bulletSpeed;

            GameObject bullet5 = Instantiate(bulletPrefab1);
            bullet5.transform.position = firePoint3.transform.position;
            bullet5.transform.LookAt(targetTransform);
            bullet5.transform.Rotate(xAngle, -30, zAngle, Space.Self);
            Rigidbody bulletRb5 = bullet5.GetComponent<Rigidbody>();
            bulletRb5.velocity = bullet5.transform.forward * bulletSpeed;
        }

        else if (burstType == "StaticThreeSpread")
        {
            GameObject bullet = Instantiate(bulletPrefab1);
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.LookAt(staticTransform);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;

            GameObject bullet2 = Instantiate(bulletPrefab1);
            bullet2.transform.position = firePoint2.transform.position;
            bullet2.transform.LookAt(staticTransform);
            bullet2.transform.Rotate(xAngle, 15, zAngle, Space.Self);
            Rigidbody bulletRb2 = bullet2.GetComponent<Rigidbody>();
            bulletRb2.velocity = bullet2.transform.forward * bulletSpeed;

            GameObject bullet3 = Instantiate(bulletPrefab1);
            bullet3.transform.position = firePoint3.transform.position;
            bullet3.transform.LookAt(staticTransform);
            bullet3.transform.Rotate(xAngle, -15, zAngle, Space.Self);
            Rigidbody bulletRb3 = bullet3.GetComponent<Rigidbody>();
            bulletRb3.velocity = bullet3.transform.forward * bulletSpeed;

        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        //print("NOT visible");
    }

    void OnBecameVisible()
    {
        gameObject.SetActive(true);
        //print("VISIBLE");
    }
}
