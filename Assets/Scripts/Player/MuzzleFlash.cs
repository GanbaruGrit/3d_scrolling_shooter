using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    Animator muzzleAnimator;
    PlayerWeaponManager playerWeaponManager;
    void Start()
    {
        muzzleAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            muzzleAnimator.Play("MuzzleFlash");
        }
    }
    
}
