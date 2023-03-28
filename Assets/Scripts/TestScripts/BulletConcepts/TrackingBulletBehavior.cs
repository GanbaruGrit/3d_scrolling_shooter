using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBulletBehavior : MonoBehaviour
{
    [Header("References")]
    public EnemyShotData enemyShotData;
    private EnemyBulletSpawner enemyBulletSpawner;
    Rigidbody rb;
    public GameObject hitSpark;
    [SerializeField] private AudioSource hitAudio;

    [Header("Targets")]
    [SerializeField] private bool multiTarget;
    [SerializeField] private bool randomizeFirstTarget;
    public Transform firstTargetTransform;
    private Transform firstTargetAdjusted;
    public Transform secondTargetTransform;
    public Transform finalTargetTransform;

    [Header("Timing")]
    float timeBeforeDirectionChange;
    float pauseTime;
    private bool secondStepReady;
    private bool shotPaused;

    [SerializeField] float lifetime;
    [SerializeField] float acceleration;
    [SerializeField] float velocity;
    [SerializeField] float maxVelocity;
    [SerializeField] float firstVelocity;
    [SerializeField] float startVelocity;
    [SerializeField] float accelerationModifier = 1f;

    [SerializeField] public int damage = 1;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyBulletSpawner = GetComponentInParent<EnemyBulletSpawner>();

        firstTargetTransform = enemyBulletSpawner.firstTargetTransform;
        firstTargetAdjusted = firstTargetTransform;
        secondTargetTransform = enemyBulletSpawner.secondTargetTransform;
        finalTargetTransform = enemyBulletSpawner.finalTargetTransform;
        timeBeforeDirectionChange = enemyBulletSpawner.timeBeforeDirectionChange;
        pauseTime = enemyBulletSpawner.pauseTime;
        randomizeFirstTarget = enemyBulletSpawner.randomizeFirstTarget;
        velocity = enemyShotData.bulletSpeed;

        

        //AddRandomToFirstTarget();
        StartShoot();
    }

    private void FixedUpdate()
    {
        acceleration = velocity / Time.deltaTime;
        //print("Velocity: " + velocity);
        //print("Acceleration: " + acceleration);
        //IncreaseVelocityFirst();
        //IncreaseVelocitySecond();
        if (!shotPaused) rb.AddForce(transform.forward * velocity);
    }

    Transform GetFirstTarget()
    {
        return firstTargetTransform = enemyBulletSpawner.firstTargetTransform;
    }
    public void StartShoot()
    {
        if (randomizeFirstTarget)
        {
            transform.LookAt(firstTargetAdjusted);
        } else
        {
            transform.LookAt(firstTargetTransform);
        }

        Invoke("MoveToSecondTarget", timeBeforeDirectionChange);
    }

    private void MoveToSecondTarget()
    {
        rb.velocity = Vector3.zero;
        transform.LookAt(finalTargetTransform);
        transform.parent = null; // remove parent to avoid moving mid-air bullets
        StartCoroutine(PauseBeforeDirectionChange());
    }

    IEnumerator PauseBeforeDirectionChange()
    {
        shotPaused = true;
        yield return new WaitForSeconds(pauseTime);
        shotPaused = false;
    }

    void AddRandomToFirstTarget()
    {
        var xOffset = Random.Range(-1, 1);
        //firstTargetAdjusted.position.x += xOffset;
    }

    private void IncreaseVelocityFirst()
    {
        transform.LookAt(firstTargetTransform);

        if (velocity < firstVelocity && !secondStepReady)
        {
            velocity += Time.deltaTime * accelerationModifier;
        }

        if (velocity >= firstVelocity && !secondStepReady)
        {

            StartCoroutine(Pause(pauseTime));
        }



    }

    private void IncreaseVelocitySecond()
    {
        //var adjustedEulerAngles = transform.eulerAngles + new Vector3(0, 0, 5);
        //transform.eulerAngles = adjustedEulerAngles;

        transform.LookAt(firstTargetTransform);

        if (secondStepReady && velocity < maxVelocity)
        {
            velocity += Time.deltaTime * accelerationModifier;
        }
    }

    private IEnumerator Pause(float pauseTime)
    {
        print("Pause hit");
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(pauseTime);
        print("Pause done");

        secondStepReady = true;
    }

    public void DestroySelf()
    {
        //gameObject.SetActive(false);
        //BulletSpawner.Instance.KillBullet(this);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Bullet Collide");
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        //Instantiate(hitSpark, collision.transform.position, collision.transform.rotation);
        //hitAudio.Play();
        DestroySelf();
    }



    private void PauseShot()
    {
        rb.velocity = Vector3.zero;
    }

    private void ResumeShot()
    {
        rb.velocity = Vector3.zero;
    }

    public void OnEnable()
    {
        Invoke("DestroySelf", lifetime); // destroys bullet after time
    }

    private void OnBecameInvisible()
    {
        //DestroySelf();
    }
}
