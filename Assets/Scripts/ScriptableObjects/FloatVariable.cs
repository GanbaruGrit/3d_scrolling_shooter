using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "ScriptableObjects/FloatVariable", order = 1)]

public class FloatVariable : ScriptableObject
{

    public float score;
    public float lives;
    public float defaultScore = 0;
    public float defaultLives = 3;

}
