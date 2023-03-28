using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerWeaponManager : MonoBehaviour
{
    //public ObjectPool<GameObject> _pool;
    //[SerializeField] public bool _usePool;
    public BulletSpawner bulletSpawner;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] GameObject powerShotPrefab;
    [SerializeField] GameObject optionShotPrefab;
    public GameObject optionPrefab1;
    public GameObject optionPrefab2;
    MeshRenderer meshRenderer;
    public GameObject muzzleFlashPrefab;
    public GameObject optionMuzzleFlashPrefab;

    [Header("Audio")]
    [SerializeField] string shotAudioName;
    [SerializeField] string powerShotAudioName;
    [SerializeField] string pickupAudioName;
    [SerializeField] string chargeResetAudioName;
    [SerializeField] string swordAudioName;
    bool playChargeResetSound = false;

    [Header("FirePoints")]
    public Transform firePointCenter;
    public Transform firePointRight;
    public Transform firePointLeft;
    public Transform firePointRight2;
    public Transform firePointLeft2;
    public Transform firePointRight3;
    public Transform firePointLeft3;

    public Transform optionFirePointLeft_1;
    public Transform optionFirePointRight_1;
    public Transform optionFirePointLeft_2;
    public Transform optionFirePointRight_2;

    public Transform rotatingFirePoint_1;
    public Transform rotatingFirePoint_2;
    public Transform rotatingFirePoint_3;
    public Transform rotatingFirePoint_4;

    [Header("Shot Settings")]
    [SerializeField] public float shootDelay;
    [SerializeField] float timeToFullCharge;
    [SerializeField] float chargeTimer;
    public bool isShooting;
    private int bulletType;
    private int weaponLevel = 1;
    public int optionLevel;

    [SerializeField] public float playerShotDamage;
    [SerializeField] public float playerChargeShotDamage;
    [SerializeField] private float level1Distance;
    [SerializeField] private float level2Distance;
    [SerializeField] private float level3Distance;

    Color defaultColor;
    RandomSound soundScript;
    [SerializeField] bool menuMode = false;

    void Start()
    {
        // Alternate object pooling code
        /* 
        _pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(bulletPrefab);
        }, bulletPrefab =>
        {
            bulletPrefab.SetActive(true);
        }, bulletPrefab =>
        {
            bulletPrefab.SetActive(false);
        }, bulletPrefab =>
        {
            Destroy(bulletPrefab.gameObject);
        }, false, 10, 20);
        */
        
        SetWeapon(1);

        //bulletSpawner = GetComponent<BulletSpawner>();

        meshRenderer = GetComponent<MeshRenderer>();

        defaultColor = meshRenderer.material.color;

        soundScript = GetComponent<RandomSound>();
    }

    void Update()
    {
        if (menuMode) SetWeapon(5);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetWeapon(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetWeapon(5);
        }

        // PowerShot logic
        chargeTimer += Time.deltaTime;

        if (chargeTimer < timeToFullCharge)
        {
            meshRenderer.material.color = Color.blue;
            playChargeResetSound = false;
        }
        else if ((chargeTimer > timeToFullCharge) && playChargeResetSound == false)
        {
            meshRenderer.material.color = Color.red;
            FindObjectOfType<AudioManager>().Play(chargeResetAudioName);
            playChargeResetSound = true;
        }

        DistanceToTarget();
    }

    public void DistanceToTarget() // For changing player shot color as distance to target decreases
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.distance < level1Distance)
            {
                bulletPrefab.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_EmissionColor", Color.red * 20);
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
                
            }
            else if (hitInfo.distance < level2Distance)
            {
                bulletPrefab.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_EmissionColor", Color.red * 10);
                Debug.DrawLine(ray.origin, hitInfo.point, Color.yellow);
            }
            else if (hitInfo.distance < level3Distance)
            {
                bulletPrefab.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_EmissionColor", Color.red * 5);
                Debug.DrawLine(ray.origin, hitInfo.point, Color.green);
                
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.blue);
                bulletPrefab.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_EmissionColor", Color.yellow * 5);
            }
        }
    }

    public void Shoot()
    {
        if (isShooting) return;
        
        soundScript.CallAudio();
        isShooting = true;
        Instantiate(muzzleFlashPrefab, transform.position, transform.rotation);
        Invoke("ResetShoot", shootDelay);
        OptionShoot();

        if (bulletType == 0)
        {
            bulletSpawner.TestBullet();
        }

        if (bulletType == 1)
        {
            bulletSpawner.CreateBullet(firePointLeft.position, firePointLeft.rotation);
            bulletSpawner.CreateBullet(firePointRight.position, firePointRight.rotation);
        }

        else if (bulletType == 2)
        {
            bulletSpawner.CreateBullet(firePointLeft.position, firePointLeft.rotation);
            bulletSpawner.CreateBullet(firePointRight.position, firePointRight.rotation);

            bulletSpawner.CreateBullet(firePointLeft2.position, firePointLeft2.rotation);
            bulletSpawner.CreateBullet(firePointRight2.position, firePointRight2.rotation);
        }

        else if (bulletType == 3)
        {
            bulletSpawner.CreateBullet(firePointCenter.position, firePointCenter.rotation);

            bulletSpawner.CreateBullet(firePointLeft.position, firePointLeft.rotation);
            bulletSpawner.CreateBullet(firePointRight.position, firePointRight.rotation);

            bulletSpawner.CreateBullet(firePointLeft2.position, firePointLeft2.rotation);
            bulletSpawner.CreateBullet(firePointRight2.position, firePointRight2.rotation);

            bulletSpawner.CreateBullet(firePointLeft3.position, firePointLeft3.rotation);
            bulletSpawner.CreateBullet(firePointRight3.position, firePointRight3.rotation);
        }

        else if (bulletType == 4)
        {
            bulletSpawner.CreateBullet(firePointCenter.position, firePointCenter.rotation);

            bulletSpawner.CreateBullet(firePointLeft.position, firePointLeft.rotation);
            bulletSpawner.CreateBullet(firePointRight.position, firePointRight.rotation);

            bulletSpawner.CreateBullet(firePointLeft2.position, firePointLeft2.rotation);
            bulletSpawner.CreateBullet(firePointRight2.position, firePointRight2.rotation);

            bulletSpawner.CreateBullet(firePointLeft3.position, firePointLeft3.rotation);
            bulletSpawner.CreateBullet(firePointRight3.position, firePointRight3.rotation);

            bulletSpawner.CreateBullet(rotatingFirePoint_1.position, rotatingFirePoint_1.rotation);
            bulletSpawner.CreateBullet(rotatingFirePoint_2.position, rotatingFirePoint_2.rotation);
        }

        else if (bulletType >= 5)
        {
            bulletSpawner.CreateBullet(firePointCenter.position, firePointCenter.rotation);

            bulletSpawner.CreateBullet(firePointLeft.position, firePointLeft.rotation);
            bulletSpawner.CreateBullet(firePointRight.position, firePointRight.rotation);

            bulletSpawner.CreateBullet(firePointLeft2.position, firePointLeft2.rotation);
            bulletSpawner.CreateBullet(firePointRight2.position, firePointRight2.rotation);

            bulletSpawner.CreateBullet(firePointLeft3.position, firePointLeft3.rotation);
            bulletSpawner.CreateBullet(firePointRight3.position, firePointRight3.rotation);

            bulletSpawner.CreateBullet(rotatingFirePoint_1.position, rotatingFirePoint_1.rotation);
            bulletSpawner.CreateBullet(rotatingFirePoint_2.position, rotatingFirePoint_2.rotation);

            bulletSpawner.CreateBullet(rotatingFirePoint_3.position, rotatingFirePoint_3.rotation);
            bulletSpawner.CreateBullet(rotatingFirePoint_4.position, rotatingFirePoint_4.rotation);
        }
    }

    private void OptionShoot()
    {
        if (optionLevel == 1)
        {
            Instantiate(optionMuzzleFlashPrefab, (optionFirePointLeft_1.position + new Vector3(0, 0, .5f)), optionFirePointLeft_1.rotation);
            GameObject optionBullet = Instantiate(optionShotPrefab, optionFirePointLeft_1.position, optionFirePointLeft_1.rotation);

            Instantiate(optionMuzzleFlashPrefab, (optionFirePointRight_1.position + new Vector3(0, 0, .5f)), optionFirePointRight_1.rotation);
            GameObject optionBullet2 = Instantiate(optionShotPrefab, optionFirePointRight_1.position, optionFirePointRight_1.rotation);
        }
        
        if (optionLevel >= 2)
        {
            Instantiate(optionMuzzleFlashPrefab, (optionFirePointLeft_1.position + new Vector3(0, 0, .5f)), optionFirePointLeft_1.rotation);
            GameObject optionBullet = Instantiate(optionShotPrefab, optionFirePointLeft_1.position, optionFirePointLeft_1.rotation);

            Instantiate(optionMuzzleFlashPrefab, (optionFirePointRight_1.position + new Vector3(0, 0, .5f)), optionFirePointRight_1.rotation);
            GameObject optionBullet2 = Instantiate(optionShotPrefab, optionFirePointRight_1.position, optionFirePointRight_1.rotation);

            Instantiate(optionMuzzleFlashPrefab, (optionFirePointLeft_2.position + new Vector3(0, 0, .5f)), optionFirePointLeft_2.rotation);
            GameObject optionBullet3 = Instantiate(optionShotPrefab, optionFirePointLeft_2.position, optionFirePointLeft_2.rotation);

            Instantiate(optionMuzzleFlashPrefab, (optionFirePointRight_2.position + new Vector3(0, 0, .5f)), optionFirePointRight_2.rotation);
            GameObject optionBullet4 = Instantiate(optionShotPrefab, optionFirePointRight_2.position, optionFirePointRight_2.rotation);
        }
    }

    public void PowerShoot()
    {
        if (chargeTimer >= timeToFullCharge)
        {
            chargeTimer = 0;
            GameObject powerShotBullet = Instantiate(powerShotPrefab, firePointCenter.position, firePointCenter.rotation);
            FindObjectOfType<AudioManager>().Play(powerShotAudioName);
            FindObjectOfType<AudioManager>().Play(swordAudioName);

        }
    }

    

    public void SetBulletPrefab(int bulletNum)
    {
        bulletType = bulletNum;
    }

    void ResetShoot()
    {
        isShooting = false;
        
    }

    public void SetWeapon(int weaponID)
    {
        switch (weaponID)
        {
            case 1:
                SetBulletPrefab(1);
                shootDelay = 0.2f;
                
                break;
            case 2:
                SetBulletPrefab(2);
                shootDelay = 0.17f;
                
                break;
            case 3:
                SetBulletPrefab(3);
                shootDelay = 0.15f;
                
                break;
            case 4:
                SetBulletPrefab(4);
                shootDelay = 0.12f;

                break;

            case 5:
                SetBulletPrefab(5);
                shootDelay = 0.10f;

                break;
        }
    }

    // Functions to manage power ups and options
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            weaponLevel++;
            SetWeapon(weaponLevel);
            FindObjectOfType<AudioManager>().Play(pickupAudioName);
            other.gameObject.GetComponent<PowerUp>().DestroySelf();
        }

        if (other.CompareTag("OptionUp"))
        {
            optionLevel++;
            FindObjectOfType<AudioManager>().Play(pickupAudioName);
            CreateOption();
            other.gameObject.GetComponent<PowerUp>().DestroySelf();
        }
    }

    private void CreateOption()
    {
        if (optionLevel == 1)
        {
            optionPrefab1.SetActive(true);
        }

        if (optionLevel == 2)
        {
            optionPrefab2.SetActive(true);
        }
    }

}
