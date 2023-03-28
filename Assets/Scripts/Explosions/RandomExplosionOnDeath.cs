using UnityEngine;

public class RandomExplosionOnDeath : MonoBehaviour
{
    [SerializeField] private GameObject CommonExplosionPrefab1;
    [SerializeField] private GameObject CommonExplosionPrefab2;
    [SerializeField] private GameObject RareExplosionPrefab;
    [SerializeField] private bool explosionDrift;
    [SerializeField] private float driftAmount;
    private GameObject explosion;

    private void Update()
    {
        if (explosion) explosion.transform.Translate(0, 0, driftAmount);
    }
    public void RandomExplode()
    {
        float randValue = Random.value;

        if (randValue < .45f) // 45% of the time
        {
            explosion = Instantiate(CommonExplosionPrefab1, transform.position, transform.rotation);
        }
        else if (randValue < .9f) // 45% of the time
        {
            explosion = Instantiate(CommonExplosionPrefab2, transform.position, transform.rotation);
        }
        else // 10% of the time
        {
            explosion = Instantiate(RareExplosionPrefab, transform.position, transform.rotation);
        }        
    }
}
