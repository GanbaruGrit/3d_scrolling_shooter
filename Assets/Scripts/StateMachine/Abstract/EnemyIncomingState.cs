using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIncomingState : EnemyBaseState
{

    
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Hello from the ENTER incoming state");
        //IncomingMovementDelegate temp = enemy.GetComponent<EnemyMovement>().incomingMovement;
        //State state = enemy.GetComponent<EnemyMovement>().state = State SwingLR;
        //stateType = state.GetType;

    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        Debug.Log("Hello from the UPDATE incoming state");

        //if (enemy.GetComponent<SwingLR>().movementFinished)
        //{
        //    enemy.SwitchState(enemy.ChaseState);
        //}


    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {

    }
}
