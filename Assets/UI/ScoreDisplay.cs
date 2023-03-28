using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;   
    public FloatVariable playerStats;
    void Start()
    {
        
    }

    
    void Update()
    {
        scoreText.SetText("Score: " + playerStats.score);
    }
}
