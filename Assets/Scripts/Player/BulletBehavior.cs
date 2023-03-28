using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody rb;
    PlayerWeaponManager playerWeaponManager;
    public GameObject hitSpark;
    Rigidbody playerRb;

    [SerializeField] private AudioSource hitAudio;
    [SerializeField] private float bulletSpeed;
    [SerializeField] public float damage;
    [SerializeField] public float timeAlive = 8f;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRb = GetComponent<Rigidbody>();
        playerWeaponManager = GameObject.Find("Player").GetComponent<PlayerWeaponManager>();

        damage = playerWeaponManager.playerShotDamage;

        StartShoot();
    }

    // Alternate object pooling code:
    /* public void Init(Action<BulletBehavior> killAction)
    {
        _killAction = killAction;
    }*/

    public void DestroySelf()
    {
        gameObject.SetActive(false);
        //BulletSpawner.Instance.KillBullet(this);
        Destroy(gameObject);
    }

    public void StartShoot()
    {
        rb.velocity = new Vector3(0, 0, bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Quaternion rotation = Quaternion.Euler(contact.normal);
        Vector3 position = contact.point;

        Instantiate(hitSpark, transform.position, transform.rotation);

        rb.useGravity = true;
        rb.AddForce(new Vector3(UnityEngine.Random.Range(-40f, 40f), UnityEngine.Random.Range(-40f, 40f), 0)); // might not be worth processing
        if (TryGetComponent(out ShrinkObject shrinkObject))
        {
            shrinkObject.enabled = true;
        }
    }


    public void OnEnable()
    {
        Invoke("DestroySelf", timeAlive); // destroys bullet after time
        
    }
}
