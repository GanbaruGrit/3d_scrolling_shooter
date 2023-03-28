using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashRed : MonoBehaviour
{
    
    [SerializeField] private MeshRenderer meshRenderer;
    private Color defaultColor;
    public Enemy enemyScript;
    
    void Start()
    {
        defaultColor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.health <= 0)
        {
            meshRenderer.material.DOColor(Color.gray, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("PlayerShot"))
        {
            meshRenderer.material.DOColor(Color.red, 0.2f).OnComplete(() =>
            {
                meshRenderer.material.DOColor(defaultColor, 0.2f);
            });
        }
        
    }
}
