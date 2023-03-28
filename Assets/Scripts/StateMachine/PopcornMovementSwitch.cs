using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornMovementSwitch : MonoBehaviour
{
    public float timer = 2;
    
    enum State
    {
        Incoming,
        Idle,
        Chasing,
        Leaving
    }

    [SerializeField] State state = new State();



    void Start()
    {
        switch (state)
        {
            case State.Incoming:
                print("Incoming State");
                GetComponent<SwingLR>().DoSwingLR();
                
                break;

            case State.Idle:
                print("Idle State");
                break;

            case State.Chasing:
                print("Chasing State");
                break;

            case State.Leaving:
                print("Leaving State");
                break;

        }
    }

    
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer == 0)
        {
            state = State.Chasing;
        }

    }
}
