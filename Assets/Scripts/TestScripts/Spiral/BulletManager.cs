using UnityEngine;
using System.Collections.Generic;
public class BulletManager : MonoBehaviour
{
    public static List<GameObject> bullets;
    private void Start()
    {
        bullets = new List<GameObject>();
    }
    public static GameObject GetBulletFromPool()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].active)
            {
                var b = bullets[i].GetComponent<Bullet>();
                b.timer = b.lifeTime;
                bullets[i].SetActive(true);
                return bullets[i];
            }
        }
        return null;
    }
    public static GameObject GetBulletFromPoolWithType(string type)
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].active && bullets[i].GetComponent<Bullet>().type == type)
                return bullets[i];
        }
        return null;
    }
}
