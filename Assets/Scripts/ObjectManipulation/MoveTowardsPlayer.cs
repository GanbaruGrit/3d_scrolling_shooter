using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    Enemy enemyScript;

    public float speed = 4.0f;
    private Transform target;
    public bool isMoving = true;
    public float randomNum;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyScript = GetComponent<Enemy>();
    }

    
    void Update()
    {
        //if (enemyScript.isAlive == true)
        //{
        //    //print("Movetowards hit, isAlive = " + enemyScript.isAlive);
        //    MoveTowardsTarget();
        //} else if (enemyScript = null)
        //{
        //    MoveTowardsTarget();
        //}

        MoveTowardsTarget();
    }

    public void MoveTowardsTarget()
    {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            //print("isMoving turned ON: " + isMoving);
    }

    public void ToggleMoveTowardsTarget() // The core 'do movement' function
    {
        if (isMoving == false)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            //print("isMoving turned ON: " + isMoving);
            isMoving = true;
        } else
        {
            //print("isMoving turned OFF: " + isMoving);
            isMoving = false;
        }   
    }

    public void SetSpecificMovement(float movement)
    {
        //print("Movement set to specific pattern" + movement);
    }

    public void SetRandomMovement()
    {
        randomNum = Random.Range(0f, 5f);
        //print("Movement set to random pattern: " + randomNum);
    }
}
