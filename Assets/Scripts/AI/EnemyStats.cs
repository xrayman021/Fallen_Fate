using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class EnemyStats : CharacterStats
    {
        //public HealthBar healthBar;

        Animator animator;



        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            //healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
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
                //Handle enemy death
            }
        }
    }
}
