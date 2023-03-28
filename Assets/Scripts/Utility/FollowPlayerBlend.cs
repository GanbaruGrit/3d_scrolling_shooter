using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerBlend : MonoBehaviour
{
    public Transform player;
    [SerializeField] float followSharpness = 0.2f;
    void Start()
    {
        //player = transform.Find("OptionFollowGuide");
    }

    

    private void FixedUpdate()
    {
        transform.position += (player.position - transform.position) * followSharpness;
    }
}
