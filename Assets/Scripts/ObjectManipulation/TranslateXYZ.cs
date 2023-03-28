using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateXYZ : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;
    [SerializeField] private float duration;
    private Vector3 currentPos;
    private float currentTime;

    void Start()
    {
        currentPos = gameObject.transform.position;
        currentTime = Time.deltaTime;

        StartCoroutine(TranslateObject());
    }

    IEnumerator TranslateObject()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * ySpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * zSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;  
        }
    }
}
