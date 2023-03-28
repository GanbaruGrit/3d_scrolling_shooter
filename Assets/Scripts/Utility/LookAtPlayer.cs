using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] float minDist = 4;
    [SerializeField] float maxDist = 20;
    [SerializeField] bool hardLock;
    EnemyWeaponManager enemyWeaponManager;

    public float turnSpeed = 1;
    GameObject target;
    public Transform partToRotate;


    private void Start()
    {
        target = GameObject.Find("Player");
        enemyWeaponManager = GetComponent<EnemyWeaponManager>();
    }

    private void Update()
    {
        if (hardLock)
        {
            transform.LookAt(target.transform.position);
        } else
        {
            Ray ray = new Ray(transform.position, (target.transform.position - transform.position));
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if ((hitInfo.distance > minDist) && (hitInfo.distance < maxDist))
                {
                    enemyWeaponManager.ToggleInRange(true);
                    Debug.DrawLine(ray.origin, hitInfo.point, Color.green);
                    LockOnTarget();
                }
                else
                {
                    enemyWeaponManager.ToggleInRange(false);
                    Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
                }
            }
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
