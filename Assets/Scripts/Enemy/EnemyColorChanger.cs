using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyColorChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    void Start()
    {
        ColorChange();
    }

    private void ColorChange()
    {
        meshRenderer.material.DOColor(Random.ColorHSV(), 0.3f).OnComplete(ColorChange);
    }
}
