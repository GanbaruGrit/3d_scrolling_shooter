using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwingRL : MonoBehaviour
{
    public Enemy enemyScript;
    private string objID;
    public bool movementFinished = false;

    [SerializeField] private PathType pathType = PathType.CatmullRom;
    [SerializeField] private float pathSpeed;

    private Vector3[] waypointEnterSwingLeft = new[] {
        new Vector3(0, 1, -10),
        new Vector3(-5, 1, -20),
        new Vector3(-10, 1, -20),
        new Vector3(-15, 1, -5),
    };

    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        objID = System.Guid.NewGuid().ToString();
    }

    
    void Update()
    {
        if (enemyScript.isAlive == false)
        {
            DOTween.Kill(objID);
        }
    }

    public void DoSwingRL()
    {
        Tween t = transform.DOPath(waypointEnterSwingLeft, pathSpeed, pathType)
                .SetOptions(false)
                .SetRelative();

        t.SetEase(Ease.Linear);
        t.OnComplete(FinishMovement);
    }

    public void FinishMovement()
    {
        movementFinished = true;
    }
}
