using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorEnemyScript : MonoBehaviour
{
    private Enemy enemyScript;
    private GameObject shell;
    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        shell = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (!enemyScript.isAlive)
        {
            for (int i = 0; i < shell.transform.childCount; i++)
            {
                GameObject child = shell.transform.GetChild(i).gameObject;
                child.GetComponent<FallApart>().ApplyGravityAndForce();
            }
        }
    }
}
