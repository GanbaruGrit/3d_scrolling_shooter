using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private PlayerWeaponManager playerWeaponManager;
    [SerializeField] private EnemyTakeDamage enemyTakeDamage;
    [SerializeField] private EnemyBulletSpawner enemyBulletSpawner;
    [SerializeField] private MeshRenderer modelMeshRenderer;
    [SerializeField] private Collider modelCollider;
    [SerializeField] private AddForce addForce;

    public Object explosionRef;
    public GameObject explosionChild;
    public CameraShake cameraShake;
    [SerializeField] private string explodeAudioName;
    
    public bool isAlive = true;
    private bool isDone = false;
    [SerializeField] private bool breakable = false;
    [SerializeField] private bool breakableSwap = false;
    [SerializeField] private GameObject piecesSwap;
    
    public FloatVariable playerScore;
    [SerializeField] private GameObject floatingText;
    [SerializeField] public float health;
    [SerializeField] public int pointValue = 1;
    void Start()
    {
        playerWeaponManager = GameObject.Find("Player").GetComponent<PlayerWeaponManager>();
        
        //playerScore = GameObject.Find("Player").GetComponent<PlayerGeneralManager>().score;
        //playerScore = PlayerGeneralManager.score;
    }

    void Update()
    {
        if (health <= 0 && !isDone)
        {
            isAlive = false;
            KillSelf();
            isDone = true;
        }
    }

    void AddScore()
    {
        playerScore.score += pointValue;
        floatingText.SetActive(true);
    }

    private void KillSelf()
    {
        isAlive = false;
        if (addForce) addForce.AddExplosiveForce();
        //explosionChild.SetActive(true);
        Invoke("DestroySelf", 6f);
        AddScore();
        //CinemamachineShake.Instance.ShakeCamera(15f, 1.6f);
        FindObjectOfType<AudioManager>().Play(explodeAudioName);

        modelMeshRenderer.enabled = false;
        modelCollider.enabled = false;

        if (enemyBulletSpawner != null)
        {
            enemyBulletSpawner.enabled = false;
        }

        if (breakable)
        {
            ExplodeForce explodeScript = GetComponent<ExplodeForce>();
            explodeScript.Explode();
            
        } else if (breakableSwap){
            Explode explodeScript = GetComponent<Explode>();
            explodeScript.ExplosionEffect();
            Instantiate(piecesSwap, transform.position, transform.rotation);
            
        } else
        {
            Explode explodeScript = GetComponent<Explode>();
            //explodeScript.ExplosionEffect();

            RandomExplosionOnDeath randomExplosionScript = GetComponent<RandomExplosionOnDeath>();
            if (randomExplosionScript != null) randomExplosionScript.RandomExplode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            health -= playerWeaponManager.playerShotDamage;
        }
    }

    private void DestroySelf()
    {        
        Destroy(gameObject);
    }
}
