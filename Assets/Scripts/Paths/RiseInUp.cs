using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RiseInUp : MonoBehaviour
{
    public Enemy enemyScript;
    Transform target;

    string objID;
    public bool mirror = false;
    bool movementFinished = false;

    [SerializeField] PathType pathType = PathType.CatmullRom;
    [SerializeField] float pathSpeed;
    [SerializeField] float chaseSpeed = 4.0f;

    private Vector3[] waypointRiseUp = new[] {
        new Vector3(0, 18, -5),
        new Vector3(0, 18, -8)
        
    };

    private Vector3[] waypointMoveDown = new[] {
        new Vector3(0, 1, -10),
        new Vector3(-5, 1, -20),
        new Vector3(-10, 1, -20),
        new Vector3(-15, 1, -5),
    };



    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //print("Target: " + target);

    }

    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        objID = System.Guid.NewGuid().ToString();
        DoRiseInUp();
    }


    void Update()
    {
        if (enemyScript.isAlive == false)
        {
            DOTween.Kill(objID);
        }

        MoveTowardsTarget();
    }

    public void DoRiseInUp()
    {
            Tween t = transform.DOPath(waypointRiseUp, pathSpeed, pathType)
                .SetOptions(false)
                .SetRelative();

            t.SetEase(Ease.Linear);
            t.OnComplete(FinishMovement);
    }

    public void FinishMovement()
    {
        //movementFinished = true;

    }

    public void MoveTowardsTarget() // The core 'do movement' function
    {
        if (movementFinished == true)
        {
            var step = chaseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

    }
}
