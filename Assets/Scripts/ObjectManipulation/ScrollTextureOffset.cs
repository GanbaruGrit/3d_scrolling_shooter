using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTextureOffset : MonoBehaviour
{
    public Renderer renderer;
    public float bgSpeedX;
    public float bgSpeedY;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer)
        {
            renderer.material.mainTextureOffset += new Vector2(bgSpeedX * Time.deltaTime, bgSpeedY * Time.deltaTime);
        }
    }
}
