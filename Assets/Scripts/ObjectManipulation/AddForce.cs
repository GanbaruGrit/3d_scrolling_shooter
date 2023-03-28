using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRad;
    [SerializeField] private float upwardsMod;
    [SerializeField] private Vector3 torque;

    private Vector3 explosionPos;

    void Start()
    {
        //AddExplosiveForce();
    }

    public void AddExplosiveForce()
    {
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, explosionRad);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRad);
            }
        }

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<Rigidbody>(out Rigidbody childRigidbody))
            {
                childRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRad);
                childRigidbody.AddTorque(torque);
            }
        }
    }
}
