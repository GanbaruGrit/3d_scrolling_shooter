using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAutomation : MonoBehaviour
{
    public Mover mover;
    public FloatVariable playerStats;
    public GameObject leftLayer;
    public GameObject rightLayer;
    public GameObject topLayer;
    public GameObject bottomLayer;
    public GameObject turretRef;
    public GameObject turretSpawn1;
    public GameObject turretSpawn2;

    bool functionCalled = false;
    void Start()
    {
        mover = GetComponent<Mover>();
        leftLayer = GameObject.Find("LeftLayer");
        rightLayer = GameObject.Find("RightLayer");
        topLayer = GameObject.Find("TopLayer");
        bottomLayer = GameObject.Find("BottomLayer");

        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.score > 5)
        {
            leftLayer.GetComponent<Mover>().MoveHor();
            rightLayer.GetComponent<Mover>().MoveHor();
        }

        if (playerStats.score > 15 && !functionCalled)
        {
            topLayer.GetComponent<Mover>().MoveVert();
            bottomLayer.GetComponent<Mover>().MoveVert();
            SpawnTurrets();
        }
    }

    private void SpawnTurrets()
    {
        Instantiate(turretRef, turretSpawn1.transform.position, turretSpawn1.transform.rotation);
        Instantiate(turretRef, turretSpawn2.transform.position, turretSpawn2.transform.rotation);
        functionCalled = true;
    }
}
