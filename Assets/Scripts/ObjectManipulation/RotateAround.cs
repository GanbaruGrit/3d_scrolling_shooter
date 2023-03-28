using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float degreesPerSecond = 45;

    void Update()
    {
        if (target) transform.RotateAround(target.transform.position, Vector3.up, degreesPerSecond * Time.deltaTime);
    }
}
