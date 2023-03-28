using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerShot : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private GameObject powerShotPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject hitSpark;
    [SerializeField] private AudioSource hitAudio;

    [SerializeField] private float timeToFullCharge;
    [SerializeField] private float chargeTimer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();        
    }

    void Update()
    {
        chargeTimer += Time.deltaTime;
        
        if (chargeTimer < timeToFullCharge)
        {
            meshRenderer.material.color = Color.blue;
            
        } else
        {
            meshRenderer.material.color = Color.red;
        }

        if (Input.GetButton("Fire2") && (chargeTimer >= timeToFullCharge))
        {
            chargeTimer = 0;
            GameObject powerShotBullet = Instantiate(powerShotPrefab, firePoint.position, firePoint.rotation);
        }
    }   
}
