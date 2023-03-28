using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollide : MonoBehaviour
{
    [SerializeField] GameObject hitSpark;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShot"))
        {
            print("Bullet Collide");
            Instantiate(hitSpark, other.transform.position, other.transform.rotation);
        }
    }
}
