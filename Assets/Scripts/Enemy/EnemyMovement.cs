using System.Collections;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    public Enemy enemyScript;
    private MeshRenderer meshRenderer;

    public PathType pathType = PathType.CatmullRom;
    private string objID;
    private Transform target;
    
    [SerializeField] private float duration;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pathSpeed;
    [SerializeField] private float _cycleLength = 2;
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] public string moveType;
    [SerializeField] private string rotateType = "standard";

    public enum IncomingAction
    {
        SwingLR,
        SwingRL,
        StrafeLR,
        StrafeRL,
        MoveTowardsPlayer
    }

    enum IdleAction
    {
        SwingLR,
        SwingRL,
        StrafeLR,
        StrafeRL,
        MoveTowardsPlayer
    }

    enum AtackAction
    {
        SwingLR,
        SwingRL,
        StrafeLR,
        StrafeRL,
        MoveTowardsPlayer
    }

    enum LeavingAction
    {
        SwingLR,
        SwingRL,
        StrafeLR,
        StrafeRL,
        MoveTowardsPlayer
    }

    public enum State
    {
        SwingLR,
        Idle,
        Chasing,
        Leaving
    }

    [SerializeField] public State state = new State();

    [SerializeField] IncomingAction incomingAction = new IncomingAction();
    [SerializeField] IdleAction idleAction = new IdleAction();
    [SerializeField] AtackAction attackAction = new AtackAction();
    [SerializeField] LeavingAction leavingAction = new LeavingAction();

    //public void DoIncomingAction()
    //{
    //    GetComponent<SwingLR>().DoSwingLR();
    //}

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyScript = GetComponent<Enemy>();
        meshRenderer = GetComponent<MeshRenderer>();
        
        /*
        incomingMovement = StrafeLR;
        runFunc = incomingMovement;
        */

        objID = System.Guid.NewGuid().ToString();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        switch (state)
        {
            case State.SwingLR:
                print("Incoming State");
                //GetComponent<SwingLR>().DoSwingLR();
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
        if (enemyScript.isAlive == false)
        {
            DOTween.Kill(objID);
        }
    }

    private void towardsPlayer()
    {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    
    public void SwingLR()
    {
        Tween t = transform.DOPath(waypointEnterSwingRight, pathSpeed, pathType)
                .SetOptions(false)
                .SetRelative();

        t.SetEase(Ease.Linear);
        //t.OnComplete(towardsPlayer);
    }

    private void SwingRL()
    {
        Tween t = transform.DOPath(waypointEnterSwingLeft, pathSpeed, pathType)
                .SetOptions(false)
                .SetRelative();

        t.SetEase(Ease.Linear);
        t.OnComplete(StrafeRL);
    }

    private void StrafeLR()
    {
        Tween t = transform.DOPath(waypointsRev, pathSpeed, pathType)
                .SetOptions(true)
                .SetRelative();

        t.SetEase(Ease.Linear).SetLoops(-1).SetId(objID);
    }

    private void StrafeRL()
    {
        Tween t = transform.DOPath(waypointsReg, pathSpeed, pathType)
                .SetOptions(true)
                .SetRelative();

        t.SetEase(Ease.Linear).SetLoops(-1).SetId(objID);
    }

    private void TweenMoveEnterTopGoRight()
    {
        meshRenderer.material.DOColor(Color.red, 3f).SetEase(Ease.Flash, 15, 1);
        Tween t = transform.DOPath(waypointsEnter, 1, pathType)
                .SetOptions(false)
                .SetRelative();

        t.SetEase(Ease.Linear);
        t.OnComplete(TweenMoveHorR);
    }

    private void TweenMoveEnterTopGoLeft()
    {
        meshRenderer.material.DOColor(Color.red, 3f).SetEase(Ease.Flash, 15, 1);
        Tween t = transform.DOPath(waypointsEnter, 1, pathType)
                .SetOptions(false)
                .SetRelative();

        t.SetEase(Ease.Linear);
        t.OnComplete(TweenMoveHorL);
    }

    private void TweenMoveHorR()
    {
        //transform.DOMove(new Vector3(10, 0, 0), _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetRelative();

        Tween t = transform.DOPath(waypointsReg, 3, pathType)
                .SetOptions(true)
                .SetRelative();
            
        t.SetEase(Ease.Linear).SetLoops(-1).SetId(objID);
    }

    private void TweenMoveHorL()
    {
        //transform.DOMove(new Vector3(10, 0, 0), _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetRelative();

        Tween t = transform.DOPath(waypointsRev, 3, pathType)
                .SetOptions(true)
                .SetRelative();

        t.SetEase(Ease.Linear).SetLoops(-1).SetId(objID);
    }

    private void TweenMoveVert()
    {
        //transform.DOMove(new Vector3(10, 0, 0), _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetRelative();

        Tween t = transform.DOPath(waypointsVert, 3, pathType)
                .SetOptions(false)
                .SetRelative();

        t.SetEase(Ease.Linear).SetId(objID);
    }
    private void TweenSpin()
    {
        transform.DORotate(new Vector3(0, 360, 0), _cycleLength * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    private void Punch()
    {

        print("Punch run!");
    }

    IEnumerator MoveRight()
    {
        float elapsedTime = 0f;

        if (elapsedTime < duration)
        {
            rb.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator MoveLeft()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            rb.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }


    // Waypoints for tweens
    private Vector3[] waypointsReg = new[] {
        new Vector3(15, 1, 0)
    };

    private Vector3[] waypointsRev = new[] {
        new Vector3(-15, 1, 0)
    };

    private Vector3[] waypointsEnter = new[] {
        new Vector3(0, 0, -10)
    };

    private Vector3[] waypointsVert = new[] {
        new Vector3(0, 7, 0)
    };

    private Vector3[] waypointEnterSwingRight = new[] {
        new Vector3(0, 1, -10),
        new Vector3(5, 1, -20),
        new Vector3(10, 1, -20),
        new Vector3(15, 1, -5),
    };

    private Vector3[] waypointEnterSwingLeft = new[] {
        new Vector3(0, 1, -10),
        new Vector3(-5, 1, -20),
        new Vector3(-10, 1, -20),
        new Vector3(-15, 1, -5),
    };
}
