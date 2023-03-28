using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleXYZ : MonoBehaviour
{
    [SerializeField] Vector3 startingScale;
    [SerializeField] Vector3 scaleChange = new Vector3(0.1f, 0.75f, 0.4f);
    [SerializeField] float duration = 5f;
    Vector3 currentScale;
    Vector3 originalScale;
    bool isScaling = false;

    void Start()
    {
        originalScale = transform.localScale;
        transform.localScale = startingScale;

        StartCoroutine(scaleOverTime(transform, scaleChange, duration));
    }

    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }

        isScaling = false;
    }

}
