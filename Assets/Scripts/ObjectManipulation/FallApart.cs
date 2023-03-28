using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallApart : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Enemy enemy;
    [SerializeField] private float explosionForce = 20;
    [SerializeField] private float explosionRad = 1;
    [SerializeField] private Vector3 torque;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (enemy.health <= 0)
        {
            ApplyGravityAndForce();
        }
    }

    public void ApplyGravityAndForce()
    {
            rb.useGravity = true;
            rb.AddExplosionForce(explosionForce, transform.position + new Vector3 (Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)), explosionRad);
            rb.AddTorque(torque);
    }
}
