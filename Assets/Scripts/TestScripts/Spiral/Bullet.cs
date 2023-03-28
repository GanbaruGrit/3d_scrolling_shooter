using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public float speed;
    public float rotation;
    public float lifeTime;
    public string type;
    public float timer;
    void Start()
    {
        timer = lifeTime;
        transform.localRotation = Quaternion.Euler(0, rotation, 0);
    }
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0) gameObject.SetActive(false);
    }
}
