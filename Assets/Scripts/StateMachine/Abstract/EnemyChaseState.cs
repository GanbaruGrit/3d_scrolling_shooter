using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    MoveTowardsPlayer moveTowardsPlayer;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Hello from the ENTER Chase state");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        Debug.Log("Hello from the UPDATE Chase state");
        enemy.GetComponent<MoveTowardsPlayer>().MoveTowardsTarget();
        
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {

    }
}
