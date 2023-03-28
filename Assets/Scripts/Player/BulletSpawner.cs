using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    public ObjectPool<BulletBehavior> _pool;
    [SerializeField] public bool _usePool;
    ObjectPooler objectPooler;


    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public GameObject powerShotPrefab;
    [SerializeField] public GameObject optionShotPrefab;
    [SerializeField] int _defaultCapacity = 100;
    [SerializeField] int _maxCapacity = 800;

    

    void Start()
    {
        // Alternate object pooling code:
        //_pool = new ObjectPool<BulletBehavior>(() =>
        //{
        //    return Instantiate(bulletPrefab);
        //}, bulletPrefab =>
        //{
        //    bulletPrefab.gameObject.SetActive(true);
        //}, bulletPrefab =>
        //{
        //    bulletPrefab.gameObject.SetActive(false);
        //}, bulletPrefab =>
        //{
        //    Destroy(bulletPrefab.gameObject);
        //}, false, _defaultCapacity, _maxCapacity);

        //objectPooler = ObjectPooler.Instance;
        
    }

    private void FixedUpdate()
    {
        //objectPooler.SpawnFromPool("PlayerShot", transform.position, Quaternion.identity);
    }

    //private void Spawn()
    //{
    //    for (int i = 0; i < _spawnAmount; i++)
    //    {
    //        var bullet = _usePool ? _pool.Get() : Instantiate(bulletPrefab);
    //        bullet.transform.position = transform.position + Random.insideUnitSphere * 10;
    //        bullet.Init(KillBullet);
    //    }
    //}

    //public void KillBullet(BulletBehavior bulletPrefab)
    //{
    //    //if (_usePool) _pool.Release(bulletPrefab);
    //    else Destroy(bulletPrefab.gameObject);
    //}

   
    public void TestBullet()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
    
    public void CreateBullet(Vector3 pos, Quaternion rot)
    {
        
        if (!_usePool) {
            Instantiate(bulletPrefab, pos, rot);
        }
        else
        {
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = pos;
                bullet.transform.rotation = rot;
                bullet.SetActive(true);
            }
        }
    }
}
