using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float delay = 0f;
    [SerializeField] private GameObject explosionEffect;
    private float countdown;
    private bool hasExploded = false;
    private float radius = 5f;
    private float force = 700f;

    void Start()
    {
        countdown = delay;
    }

    /*
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {
            ExplodeObject();
            hasExploded = true;
        }
    }
    */

    private void ExplodeObject()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            /* Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.Destroy();
            }
            */
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }

    public void ExplosionEffect()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}