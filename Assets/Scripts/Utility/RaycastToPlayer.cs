using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {   
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }
    
}
