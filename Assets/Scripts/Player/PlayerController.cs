using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public PlayerWeaponManager playerWeaponManager;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 0.5f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float hoverTime = 10f;
    [SerializeField] private bool jumping = false;
    [SerializeField] private float jumpForce = 100;

    [Header("Movement Clamps")]
    [SerializeField] float topClamp = 18f;
    [SerializeField] float bottomClamp = -18f;
    [SerializeField] float leftClamp = -18f;
    [SerializeField] float rightClamp = 18f;

    public bool controlsEnabled = true;
    [SerializeField] bool menuMode = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerWeaponManager = GetComponent<PlayerWeaponManager>();
    }

    private void Update()
    {
        if (menuMode) playerWeaponManager.Shoot();

        if (Input.GetButton("Fire1") && controlsEnabled)
        {
            playerWeaponManager.Shoot();

        }

        if (Input.GetButton("Fire2") && controlsEnabled)
        {
            playerWeaponManager.PowerShoot();
        }


        // For testing
        if (Input.GetKey("q") && controlsEnabled)
        {
            TakeDamage takeDamage = GetComponent<TakeDamage>();
            takeDamage.PlayerHit();
        }

        if (Input.GetKey("e") && controlsEnabled)
        {
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
            
        }


        // Clamp X and Z
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftClamp, rightClamp), transform.position.y, Mathf.Clamp(transform.position.z, bottomClamp, topClamp));
    }

    private void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * moveSpeed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        
        if (controlsEnabled)
        {
            if (Input.GetKey("a"))
            {
                rb.transform.Translate(-moveSpeed, 0, 0);
            }
            if (Input.GetKey("d"))
            {
                rb.transform.Translate(moveSpeed, 0, 0);
            }
            if (Input.GetKey("w"))
            {
                rb.transform.Translate(0, 0, moveSpeed);
            }
            if (Input.GetKey("s"))
            {
                rb.transform.Translate(0, 0, -moveSpeed);
            }
            if (Input.GetKeyDown("space"))
            {                   
                if (!jumping) JumpHover();
            }
        }
    }

    private void JumpHover() // To be implemented
    {
        rb.AddForce(Vector3.up * jumpForce);

        float currentY = rb.transform.position.y;

        while (currentY < jumpHeight)
        {
            //rb.transform.Translate(0, jumpSpeed, 0);
        }
    }
}
