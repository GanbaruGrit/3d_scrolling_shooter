using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralManager : MonoBehaviour
{
    public FloatVariable playerStats;
    void Start()
    {
        playerStats.score = playerStats.defaultScore;
        playerStats.lives = playerStats.defaultLives;
    }

    void Update()
    {
        if (playerStats.lives <= 0)
        {
            print("GAME OVER MAN");
        }
    }
}
