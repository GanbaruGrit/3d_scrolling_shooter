using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private PlayerController playerController;
    private MeshRenderer meshRenderer;
    private Rigidbody rigidbody;
    private PauseIntoSloMo pauseIntoSloMo;
    public CameraShake cameraShake;
    public GameObject boundaryBox;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] string explosionAudioName;
    public Transform playerSpawnPoint;
    [SerializeField] bool mortal = false;

    private Color defaultColor;
    private Vector3 defaultPos;
    private Quaternion defaultRot;

    public FloatVariable playerStats;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        meshRenderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        pauseIntoSloMo = GetComponent<PauseIntoSloMo>();

        boundaryBox.SetActive(false);

        defaultColor = meshRenderer.material.color;
        defaultPos = transform.position;
        defaultRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyShot") && mortal == true)
        {
            int bulletDamage = other.GetComponent<EnemyBulletBehavior>().damage;
            playerStats.lives -= bulletDamage;
            Destroy(other.gameObject);
            PlayerHit();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && mortal == true)
        {
            PlayerHit();
        }
            
    }

    public void PlayerHit()
    {
        print("Player hit");

        boundaryBox.SetActive(true);
        rigidbody.detectCollisions = true;
        playerController.controlsEnabled = false;

        rigidbody.AddForce(10, 0, -25, ForceMode.Impulse);

        pauseIntoSloMo.RunFreeze();

        StartCoroutine(RotateForSeconds());

        Instantiate(explosionPrefab, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play(explosionAudioName);

        //CinemamachineShake.Instance.ShakeCamera(5f, 1f);

        Invoke("FlyPlayerIn", 5f);

        //StartCoroutine(cameraShake.Shake(.15f, .4f));
    }

    private void ChangeColor()
    {
        meshRenderer.material.color = Color.white;
    }

    IEnumerator PlayerFlash()
    {
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(.5f);
        meshRenderer.material.color = defaultColor;
        yield return new WaitForSeconds(.5f);
    }

    public Color LerpWhite()
    {
        return Color.Lerp(Color.white, defaultColor, 100f);
    }

    IEnumerator RotateForSeconds()
    {
        print("rotate callecd");
        
        float time = 5;
        float speed = 500;

        while (time > 0)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * speed);
            meshRenderer.material.color = Color.green;

            time -= Time.deltaTime;

            yield return null;
            print("post wait");
            
        }
    }

    private void FlyPlayerIn()
    {
        print("FLY IN");
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play(explosionAudioName);

        meshRenderer.material.color = defaultColor;

        transform.position = defaultPos;
        transform.rotation = defaultRot;
        rigidbody.velocity = new Vector3(0, 0, 0);

        playerController.controlsEnabled = true;

        boundaryBox.SetActive(false);
    }
}
