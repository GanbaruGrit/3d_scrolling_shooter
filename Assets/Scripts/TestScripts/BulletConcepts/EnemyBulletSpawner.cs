using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    public EnemyShotData enemyShotData;

    [SerializeField] private GameObject bulletPrefab1;
    [SerializeField] private GameObject bulletPrefab2;
    [SerializeField] private GameObject bulletPrefab3;

    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject firePoint2;
    [SerializeField] private GameObject firePoint3;
    [SerializeField] private GameObject firePoint4;
    [SerializeField] private GameObject firePoint5;

    [SerializeField] private bool aimedShot;
    [SerializeField] private bool aimedPlayer;
    [SerializeField] public Transform firstTargetTransform;
    [SerializeField] public Transform secondTargetTransform;
    [SerializeField] public Transform finalTargetTransform;
    [SerializeField] public float timeBeforeDirectionChange;

    [SerializeField] private float xAngle, yAngle, zAngle;
    [SerializeField] private float xAngle2, yAngle2, zAngle2;

    [Header("Shot Settings")]
    [SerializeField] public int numOfShots;
    [SerializeField] public float timeBetweenShots;
    [SerializeField] public float timeBeforeFirstBurst;
    [SerializeField] public float timeBetweenBursts;
    [SerializeField] public float pauseTime;
    [SerializeField] public bool randomizeFirstTarget;
    [SerializeField] public float bulletSpeed;

    private float betweenBurstsTimer;
    private bool canShoot = true;
    public bool inRange = true;

    void Start()
    {
        //burstType = enemyShotData.burstType;
        //numOfShots = enemyShotData.numOfShots;
        //timeBetweenShots = enemyShotData.timeBetweenShots;
        //timeBeforeFirstBurst = enemyShotData.timeBeforeFirstBurst;
        //timeBetweenBursts = enemyShotData.timeBetweenBursts;
        //bulletSpeed = enemyShotData.bulletSpeed;

        SetFirepointRotations();
    }
     
    public enum ShotPattern
    {
        Single,
        Double, 
        ThreeSpread,
        FiveSpread
    };

    [SerializeField] ShotPattern shotPattern = new ShotPattern();

    void Update()
    {
        if (aimedShot) transform.LookAt(finalTargetTransform);

        if (aimedPlayer) finalTargetTransform = GameObject.Find("Player").transform;
        
        timeBeforeFirstBurst -= Time.deltaTime;
        betweenBurstsTimer -= Time.deltaTime;

        if (timeBeforeFirstBurst <= 0 && inRange && betweenBurstsTimer <= 0 && canShoot)
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
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
        betweenBurstsTimer = timeBetweenBursts;
        canShoot = true;
    }

    public void Shoot()
    {
        switch (shotPattern)
        {
            case ShotPattern.Single:
                var singleShot = Instantiate(bulletPrefab1, firePoint.transform.position, firePoint.transform.rotation);
                singleShot.transform.SetParent(this.transform, true);
                break;

            case ShotPattern.Double:
                var doubleShot = Instantiate(bulletPrefab1, firePoint.transform.position + new Vector3(1, 0, 0), firePoint.transform.rotation);
                doubleShot.transform.SetParent(this.transform, true);
                var doubleShot1 = Instantiate(bulletPrefab1, firePoint.transform.position + new Vector3(-1, 0, 0), firePoint.transform.rotation);
                doubleShot1.transform.SetParent(this.transform, true);
                break;

            case ShotPattern.ThreeSpread:
                var tripleShot = Instantiate(bulletPrefab1, firePoint.transform.position, firePoint.transform.rotation);
                tripleShot.transform.SetParent(this.transform, true);
                var tripleShot1 = Instantiate(bulletPrefab1, firePoint2.transform.position, firePoint2.transform.rotation);
                tripleShot1.transform.SetParent(this.transform, true);
                var tripleShot2 = Instantiate(bulletPrefab1, firePoint3.transform.position, firePoint3.transform.rotation);
                tripleShot2.transform.SetParent(this.transform, true);
                break;

            case ShotPattern.FiveSpread:
                var fiveShot = Instantiate(bulletPrefab1, firePoint.transform.position, firePoint.transform.rotation);
                fiveShot.transform.SetParent(this.transform, true);
                var fiveShot1 = Instantiate(bulletPrefab1, firePoint2.transform.position, firePoint2.transform.rotation);
                fiveShot1.transform.SetParent(this.transform, true);
                var fiveShot2 = Instantiate(bulletPrefab1, firePoint3.transform.position, firePoint3.transform.rotation);
                fiveShot2.transform.SetParent(this.transform, true);
                var fiveShot3 = Instantiate(bulletPrefab1, firePoint4.transform.position, firePoint4.transform.rotation);
                fiveShot3.transform.SetParent(this.transform, true);
                var fiveShot4 = Instantiate(bulletPrefab1, firePoint5.transform.position, firePoint5.transform.rotation);
                fiveShot4.transform.SetParent(this.transform, true);
                break;

            default:
                print("ShotPattern not defined");
                break;
        }
    }

    void SetFirepointRotations()
    {
        firePoint2.transform.Rotate(new Vector3(xAngle, yAngle, zAngle));
        firePoint3.transform.Rotate(new Vector3(-xAngle, -yAngle, -zAngle));
        firePoint4.transform.Rotate(new Vector3(xAngle2, yAngle2, zAngle2));
        firePoint5.transform.Rotate(new Vector3(-xAngle2, -yAngle2, -zAngle2));
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
