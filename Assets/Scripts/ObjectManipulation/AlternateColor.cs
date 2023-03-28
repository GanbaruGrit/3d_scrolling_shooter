using UnityEngine;
using DG.Tweening;

public class AlternateColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material material;
    private Color defaultColor;
    [SerializeField] private Color alternateColor;

    void Start()
    {
        defaultColor = meshRenderer.material.color;
        ChangeColor();
    }

    void ChangeColor()
    {
        meshRenderer.material.DOColor(Color.black, 1);
    }

}
