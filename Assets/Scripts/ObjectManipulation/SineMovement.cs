using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public Rigidbody rb;
    
    Vector3 movePos;
    Vector3 startPos;

    public float moveFreq;
    public float moveDist;
    public bool moveHori;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveHori)
        {
            movePos.x = startPos.x + Mathf.Sin(Time.time * moveFreq) * moveDist;
            transform.Translate(new Vector3(movePos.x, transform.position.y, transform.position.z));
        }
        else
        {
            movePos.y = startPos.y + Mathf.Sin(Time.time * moveFreq) * moveDist;
            transform.position = new Vector3(transform.position.x, movePos.y, transform.position.z);
        }
    }
}
