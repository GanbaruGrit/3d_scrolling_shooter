using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float destroyTimer;
    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
