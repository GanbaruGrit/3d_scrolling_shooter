using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    public float speed = 1;
    public float RotAngleY = 0;
    public float RotAngleX = 0;
    public float RotAngleZ = 0;
    public bool invert;
    public bool normal;
    public bool pingPong;
    private float rY;
   
    void Update()
    {
        PingPong();

        /*
        if (invert)
        {
            rY -= speed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, rY, 0);

            if (rY <= RotAngleY)
            {
                rY = 0;
            }
        } 
        
        if (normal)
        {
            rY += speed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, rY, 0);

            if (rY >= RotAngleY)
            {
                rY = 0;
            }
        }
        */
    }

    void PingPong()
    {
        float rY = Mathf.SmoothStep(0, RotAngleY, Mathf.PingPong(Time.time * speed, 1));
        
        transform.Rotate(0, rY, 0);
    }
}
