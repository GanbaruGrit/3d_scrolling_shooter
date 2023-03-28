using UnityEngine;

public class RotateBackground : MonoBehaviour
{
    [SerializeField] float bgRotateSpeed;
    public Transform background;
    public float bgZ;

    void Update()
    {
        background.Rotate(new Vector3(0, bgRotateSpeed, 0));
    }
}
