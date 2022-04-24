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
        CharacterManager enemyCharacterManager;

        public UIEnemyHealthBar enemyHealthBar;
        EnemyAnimatorManager enemyAnimatorManager;

        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            maxHealth = SetMaxHealthFromHealthLevel();
            enemyDead = false;
            cameraHandler = FindObjectOfType<CameraHandler>();
            enemyCharacterManager = GetComponentInParent<CharacterManager>();
            currentHealth = maxHealth;
            enemyHealthBar.SetMaxHealth(maxHealth);
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamageNoAnimation(int damage)
        {
            currentHealth = currentHealth - damage;

            enemyHealthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Back Stabbed");
                isDead = true;
                enemyAnimatorManager.anim.SetBool("isDead", true);
                //Handle enemy death
                enemyDead = true;
                if(isDead == true)
                {
                    Invoke(nameof(KillEnemy), 5.0f);
                }
                
                /*if (enemyDead)
                {
                    Invoke(nameof(KillEnemy), .5f);
                }*/
            }
        }

        public void TakeDamage(int damage, string damageAnimation = "Damage_01")
        {
            if (isDead)
            {
                enemyCharacterManager.canBeBackstabbed = false;
                return;
            }

            currentHealth = currentHealth - damage;
            enemyHealthBar.SetHealth(currentHealth);
            Debug.Log("Enemy was hit");
            //healthBar.SetCurrentHealth(currentHealth);
            animator.Play(damageAnimation);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Dead_01");
                isDead = true;
                enemyDead = true;
                if(enemyDead)
                {
                    //Invoke(nameof(KillEnemy), .5f);
                    cameraHandler.currentLockOnTarget = null;
                }
                //Handle enemy death
            }
        }

        public void KillEnemy()
        {
            animator.Play("Backstabbed_Death");
            cameraHandler.ClearLockOnTargets();
        }
    }
}
