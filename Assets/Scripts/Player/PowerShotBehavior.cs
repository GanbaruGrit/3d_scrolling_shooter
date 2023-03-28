using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerShotBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject hitSpark;

    [SerializeField] private AudioSource hitAudio;
    [SerializeField] public int damage;
    [SerializeField] private float maxDistance = 7;
    [SerializeField] private float minDistance = 1;

    [Header("Punch Settings")]
    [SerializeField] private float punchDistance;
    Vector3 positionPunch;
    [SerializeField] private float positionDuration;
    [SerializeField] private int positionVibrato;
    [SerializeField] private float positionElasticity;
    [SerializeField] private bool positionSnapping;
    [SerializeField] private Vector3 scalePunch = new Vector3(3, 0, 5);
    [SerializeField] private float scaleDuration;
    [SerializeField] private int scaleVibrato;
    [SerializeField] private float scaleElasticity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        DistanceToTarget();

        positionPunch = new Vector3(0, 0, punchDistance);

        Invoke("DestroySelf", .2f); // destroys bullet after time

        GrowSize();
        //CinemamachineShake.Instance.ShakeCamera(3f, .2f);
    }

    public void DistanceToTarget()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.distance < maxDistance && hitInfo.distance > minDistance) // Prevent shot from going through target
            {
                punchDistance = hitInfo.distance;

            } else if (hitInfo.distance < minDistance) { // Point blank wide shot
                punchDistance = 1;
                scalePunch = new Vector3(10, 0, 1);
                gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_EmissionColor", Color.red * 10);
            } else
            {
                punchDistance = maxDistance;
            }
            
        }
    }

    void GrowSize()
    {
        transform.DOPunchPosition(positionPunch, positionDuration, positionVibrato, positionElasticity, positionSnapping);
        transform.DOPunchScale(scalePunch, scaleDuration, scaleVibrato, scaleElasticity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //CinemamachineShake.Instance.ShakeCamera(3f, .2f);
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(hitSpark, position, rotation);
        hitAudio.Play();
        Destroy(gameObject);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
