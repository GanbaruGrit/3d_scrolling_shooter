using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMissle : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rocketTurnSpeed;
    [SerializeField] private float rocketSpeed;
    [SerializeField] private float randomOffset;

    [SerializeField] private float timerSinceLaunch_Contor;
    [SerializeField] private float objectLifeTimerValue;

    [SerializeField] private GameObject hitSpark;
    private PlayerWeaponManager playerWeaponManager;
    private float damage;

    // Use this for initialization
    void Start()
    {
        //rocketTurnSpeed = 50.0f;
        //rocketSpeed = 45f;
        randomOffset = 0.0f;

        timerSinceLaunch_Contor = 0;
        objectLifeTimerValue = 10;

        playerWeaponManager = GameObject.Find("Player").GetComponent<PlayerWeaponManager>();

        damage = playerWeaponManager.playerShotDamage;
    }

    void Update()
    {
        timerSinceLaunch_Contor += Time.deltaTime;

        if (target != null)
        {
            //if (timerSinceLaunch_Contor > 1)
            //{
            //    if ((target.position - transform.position).magnitude > 50)
            //    {
            //        randomOffset = 10.0f;
            //        rocketTurnSpeed = 180.0f;
            //    }
            //    else
            //    {
            //        randomOffset = 5f;
            //        //if close to target
            //        if ((target.position - transform.position).magnitude < 10)
            //        {
            //            rocketTurnSpeed = 180.0f;
            //        }
            //    }
            //}

            Vector3 direction = target.position - transform.position + Random.insideUnitSphere * randomOffset;
            direction.Normalize();
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), rocketTurnSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * rocketSpeed * Time.deltaTime);
        }

        if (timerSinceLaunch_Contor > objectLifeTimerValue)
        {
            Destroy(transform.gameObject, 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Quaternion rotation = Quaternion.Euler(contact.normal);
        Vector3 position = contact.point;

        Instantiate(hitSpark, transform.position, transform.rotation);

        
    }
}
