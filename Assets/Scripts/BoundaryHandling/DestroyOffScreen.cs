using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    [SerializeField] GameObject targetGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoundaryBox"))
        {
            Destroy(targetGameObject);
        }
    }
}
