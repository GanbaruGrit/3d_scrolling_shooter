using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    public TMP_Text livesText;
    public FloatVariable playerStats;
    void Start()
    {

    }

    void Update()
    {
        livesText.SetText("Lives: " + playerStats.lives);
    }
}
