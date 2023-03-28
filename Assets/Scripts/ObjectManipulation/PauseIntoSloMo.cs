using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseIntoSloMo : MonoBehaviour
{
    public IEnumerator coroutine;

    private void Start()
    {
        coroutine = FrozenInTime();
    }
    public void RunFreeze()
    {
        StartCoroutine(coroutine);
    }
    
    public IEnumerator FrozenInTime()
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 0.3f;

        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1f;
    }
}
