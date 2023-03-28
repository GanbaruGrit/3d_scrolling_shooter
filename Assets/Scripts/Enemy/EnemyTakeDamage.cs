using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    PlayerWeaponManager playerWeaponManager;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject hitSpark;
    [SerializeField] GameObject hitSpark2;
    [SerializeField] string impactAudioName;
    private void Start()
    {
        playerWeaponManager = GameObject.Find("Player").GetComponent<PlayerWeaponManager>();
    }

    private void Update()
    {
        if (enemy.health <= 0)
        {
            this.enabled = false;
        }
    }

    private float CalculateDamgeDone()
    {
        return enemy.health -= playerWeaponManager.playerShotDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShot"))
        {
            FindObjectOfType<AudioManager>().Play(impactAudioName);

            CalculateDamgeDone();

            Instantiate(hitSpark, other.transform.position, other.transform.rotation);
            
            if (hitSpark2) Instantiate(hitSpark2, other.transform.position, other.transform.rotation);

            other.gameObject.SetActive(false);

            //Destroy(other.gameObject);
        }

        if (other.CompareTag("PlayerPowerShot"))
        {
            FindObjectOfType<AudioManager>().Play(impactAudioName);


            float bulletDamage = playerWeaponManager.playerChargeShotDamage;
            enemy.health -= bulletDamage;

            Instantiate(hitSpark, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);
        }
    }
    
    // Original collision code for future reference:
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            FindObjectOfType<AudioManager>().Play(impactAudioName);

            float bulletDamage = playerWeaponManager.playerShotDamage;
            enemy.health -= bulletDamage;

            Instantiate(hitSpark, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

            //collision.gameObject.gameObject.SetActive(false);

            //print("EnemyTakeDamage Hit");

            //Destroy(other.gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerPowerShot"))
        {
            FindObjectOfType<AudioManager>().Play(impactAudioName);


            float bulletDamage = playerWeaponManager.playerChargeShotDamage;
            enemy.health -= bulletDamage;

            Instantiate(hitSpark, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

            Destroy(collision.gameObject.gameObject);
        }
    }
    */
}
