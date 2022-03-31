using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class EnemyStats : CharacterStats
    {
        //public HealthBar healthBar;

        Animator animator;
        bool enemyDead;
        CameraHandler cameraHandler;



        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            enemyDead = false;
            cameraHandler = FindObjectOfType<CameraHandler>();
            //healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamageNoAnimation(int damage)
        {
            currentHealth = currentHealth - damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
                //Handle enemy death
                enemyDead = true;
                if (enemyDead)
                {
                    Invoke(nameof(KillEnemy), .5f);
                }
            }
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
            {
                return;
            }

            currentHealth = currentHealth - damage;
            Debug.Log("Enemy was hit");
            //healthBar.SetCurrentHealth(currentHealth);
            animator.Play("Damage_01");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Dead_01");
                isDead = true;
                enemyDead = true;
                if(enemyDead)
                {
                    Invoke(nameof(KillEnemy), .5f);
                    cameraHandler.currentLockOnTarget = null;
                }
                //Handle enemy death
            }
        }

        public void KillEnemy()
        {
            Destroy(gameObject);
            cameraHandler.ClearLockOnTargets();
        }
    }
}
