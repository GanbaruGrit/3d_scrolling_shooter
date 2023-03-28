using UnityEngine;

public class PingPongRotation : MonoBehaviour
{
    public float speed = 1;
    public float RotAngleY = 0;
    public float RotAngleX = 0;
    public float RotAngleZ = 0;
    public bool invert;
    private float rY;

    void Update()
    {
        if (invert)
        {
            rY -= speed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, rY, 0);

            if (rY <= RotAngleY)
            {
                rY = 0;
            }
        } 
        
        else
        {
            rY += speed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, rY, 0);

            if (rY >= RotAngleY)
            {
                rY = 0;
            }
        }
    }
}
