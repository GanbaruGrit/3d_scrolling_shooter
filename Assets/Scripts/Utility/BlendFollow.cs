using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendFollow : MonoBehaviour
{
    public Transform leader;
    [SerializeField] float followSharpness = 0.2f;

    private void FixedUpdate()
    {
        transform.position += (leader.position - transform.position) * followSharpness;
    }
    
}
