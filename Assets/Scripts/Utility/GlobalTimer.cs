using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalTimer : MonoBehaviour
{
    [SerializeField] public float globalGameTime;
    [SerializeField] public float timeScale = 1.0f;
    float currentGlobalTime;
    public TMP_Text globalTimerText;
    private float fixedDeltaTime;

    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    private void Update()
    {
        globalGameTime += Time.deltaTime;

        Time.timeScale = timeScale;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;

        string minutes = Mathf.Floor(globalGameTime / 60).ToString("00");
        string seconds = Mathf.Floor(globalGameTime % 60).ToString("00");

        if (globalTimerText) globalTimerText.SetText("Time: " + string.Format("{0}:{1}", minutes, seconds));
    }
    
}
