using UnityEngine;
using DG.Tweening;

public class Mover : MonoBehaviour
{
    [SerializeField] public float xDist;
    [SerializeField] public float zDist;
    [SerializeField] public float duration;

    public void MoveHor()
    {
        transform.DOLocalMoveX(xDist, duration).SetEase(Ease.Linear);
    }

    public void MoveVert()
    {
        transform.DOLocalMoveZ(zDist, duration).SetEase(Ease.Linear);
    }
}
