using UnityEngine;

public class NoShootZone : MonoBehaviour
{
    [SerializeField] EnemyBulletSpawner enemyBulletSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NoShootZone"))
        {
            enemyBulletSpawner.enabled = false;
        }
    }
}
