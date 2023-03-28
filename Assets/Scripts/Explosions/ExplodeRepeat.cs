using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRepeat : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    
    [SerializeField]
    int repeatAmount;
    int currentCount = 1;
    [SerializeField]
    float repeatInterval;

    void Start()
    {
        StartCoroutine("StartExplosion");
    }

    IEnumerator StartExplosion()
    {
        while (currentCount <= repeatAmount)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(repeatInterval);
            currentCount++;
        }
    }
}
