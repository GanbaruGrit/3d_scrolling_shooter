using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    PlayerWeaponManager playerWeaponManager;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    private AddForce addForce;
    public Object explosionRef;
    public GameObject explosionChild;
    public CameraShake cameraShake;
    public GameObject hitSpark;
    public GameObject powerUpPrefab;
    [SerializeField] string explodeAudioName;
    [SerializeField] string impactAudioName;

    public bool isAlive = true;
    private bool isDone = false;
    [SerializeField] private bool breakable = false;
    [SerializeField] private bool breakableSwap = false;
    [SerializeField] GameObject piecesSwap;

    public FloatVariable playerScore;

    [SerializeField] public float health;
    [SerializeField] public int pointValue = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addForce = GetComponent<AddForce>();
        playerWeaponManager = GameObject.Find("Player").GetComponent<PlayerWeaponManager>();

        //playerScore = GameObject.Find("Player").GetComponent<PlayerGeneralManager>().score;
        //playerScore = PlayerGeneralManager.score;
    }

    void Update()
    {
        if (health <= 0 && !isDone)
        {
            isAlive = false;
            //rb.useGravity = true;
            KillSelf();
            isDone = true;
        }
    }

    void AddScore()
    {
        //GameObject.Find("Player").GetComponent<PlayerGeneralManager>().score += pointValue;
        playerScore.score += pointValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShot"))
        {
            FindObjectOfType<AudioManager>().Play(impactAudioName);

            float bulletDamage = playerWeaponManager.playerShotDamage;
            health -= bulletDamage;

            Instantiate(hitSpark, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);
        }

        if (other.CompareTag("PlayerPowerShot"))
        {
            FindObjectOfType<AudioManager>().Play(impactAudioName);

            float bulletDamage = playerWeaponManager.playerChargeShotDamage;
            health -= bulletDamage;

            Instantiate(hitSpark, other.transform.position, other.transform.rotation);

            //Destroy(other.gameObject);
        }
    }

    private void Patrol()
    {
        rb.velocity = new Vector3(-1, rb.velocity.y);
        //animator.Play("grunt_run");
        transform.localScale = new Vector3(-1, 1, 1);
    }

    private void KillSelf()
    {

        //animator.SetBool("IsDead", true);
        //Invoke("Respawn", delayBeforeDestroy);
        isAlive = false;
        //addForce.AddExplosiveForce();
        //explosionChild.SetActive(true);
        Invoke("DestroySelf", 3f);
        AddScore();
        CinemamachineShake.Instance.ShakeCamera(2.5f, .3f);
        FindObjectOfType<AudioManager>().Play(explodeAudioName);

        if (breakable)
        {
            ExplodeForce explodeScript = GetComponent<ExplodeForce>();
            explodeScript.Explode();

        }
        else if (breakableSwap)
        {
            Explode explodeScript = GetComponent<Explode>();
            explodeScript.ExplosionEffect();
            Instantiate(piecesSwap, transform.position, transform.rotation);

        }
        else
        {
            Explode explodeScript = GetComponent<Explode>();
            explodeScript.ExplosionEffect();
        }

        Instantiate(powerUpPrefab, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }

    private void DestroySelf()
    {

        gameObject.SetActive(false);
    }
}
