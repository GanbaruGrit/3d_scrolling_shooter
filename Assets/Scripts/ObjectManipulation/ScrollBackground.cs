using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] float bgScrollSpeed;
    public Transform background;
    public GameObject screenBoundary;

    //public float bgZ;
    void Start()
    {
        //screenBoundary = GameObject.Find("ScreenBoundary");
    }

    
    void Update()
    {
        background.Translate(Vector3.back * Time.deltaTime * bgScrollSpeed);
        //screenBoundary.transform.Translate(Vector3.back * Time.deltaTime * bgScrollSpeed);
    }
}
