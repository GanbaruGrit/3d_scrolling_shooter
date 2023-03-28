using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    [SerializeField] private string stateID;
    [SerializeField] Animator animator;

    [SerializeField] EnemyBulletSpawner enemyBulletSpawner;
    [SerializeField] EnemyBulletSpawner enemyBulletSpawner1;
    [SerializeField] EnemyBulletSpawner enemyBulletSpawner2;
    [SerializeField] EnemyBulletSpawner enemyBulletSpawner3;

    [SerializeField] GameObject enemyBulletSpawnerSpread;
    [SerializeField] GameObject enemyBulletSpawnerSpread1;
    [SerializeField] GameObject enemyBulletSpawnerSpread2;
    [SerializeField] GameObject enemyBulletSpawnerSpread3;

    [SerializeField] Enemy enemyScript;
    [SerializeField] Enemy enemyScript1;
    [SerializeField] Enemy enemyScript2;
    [SerializeField] Enemy enemyScript3;

    [SerializeField] private float totalBossHealth;

    void Update()
    {
        totalBossHealth = enemyScript.health + enemyScript1.health + enemyScript2.health + enemyScript3.health;

        if (totalBossHealth <= 200) {
            stateID = "rotating";
        }

        if (totalBossHealth <= 100)
        {
            stateID = "spread";
        }

        if (totalBossHealth <= 50)
        {
            stateID = "dying";
        }

        if (totalBossHealth <= 0)
        {
            Destroy(gameObject);
        }

        SetState(stateID);
    }

    public void SetState(string stateID)
    {
        switch (stateID)
        {
            case "rotating":
                animator.SetTrigger("Rotating");
                enemyBulletSpawner.numOfShots = 3;
                enemyBulletSpawner1.numOfShots = 3;
                enemyBulletSpawner2.numOfShots = 3;
                enemyBulletSpawner3.numOfShots = 3;
                break;

            case "spread":
                animator.SetTrigger("Spread");
                enemyBulletSpawner.numOfShots = 0;
                enemyBulletSpawner1.numOfShots = 0;
                enemyBulletSpawner2.numOfShots = 0;
                enemyBulletSpawner3.numOfShots = 0;

                if (enemyBulletSpawnerSpread) enemyBulletSpawnerSpread.SetActive(true);
                if (enemyBulletSpawnerSpread1) enemyBulletSpawnerSpread1.SetActive(true);
                if (enemyBulletSpawnerSpread2) enemyBulletSpawnerSpread2.SetActive(true);
                if (enemyBulletSpawnerSpread3) enemyBulletSpawnerSpread3.SetActive(true);
                break;

            case "dying":
                animator.SetTrigger("Dying");
                enemyBulletSpawner.numOfShots = 3;
                enemyBulletSpawner1.numOfShots = 3;
                enemyBulletSpawner2.numOfShots = 3;
                enemyBulletSpawner3.numOfShots = 3;
                break;
        }
    }
}
