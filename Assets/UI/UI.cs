using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textDisplay.text = "Example Text";
        
    }
}
