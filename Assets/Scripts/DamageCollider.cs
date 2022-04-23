using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class DamageCollider : MonoBehaviour
    {
        public CharacterManager characterManager;
        BoxCollider damageCollider;

        public int currentWeaponDamage = 25;

        private void Start()
        {
            damageCollider = GetComponent<BoxCollider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            damageCollider.enabled = false;
        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDamageCollider()
        {
            if(damageCollider != null)
            {
                damageCollider.enabled = false;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.tag == "Player")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                CharacterManager enemyCharacterManager = collision.GetComponent<CharacterManager>();
                BlockingCollider shield = collision.transform.GetComponentInChildren<BlockingCollider>();

                if(enemyCharacterManager != null)
                {
                    
                    if(enemyCharacterManager.isParrying)
                    {
                        Debug.Log("Enemy Parrying: " + enemyCharacterManager.isParrying);
                        characterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried", true);
                        return;
                    }
                    else if(shield != null && enemyCharacterManager.isBlocking)
                    {
                        float physicalDamageAfterBlock = currentWeaponDamage - (currentWeaponDamage * shield.blockingPhysicalDamageAbsorption) / 100;
                        if(playerStats != null)
                        {
                            playerStats.TakeDamage(Mathf.RoundToInt(physicalDamageAfterBlock), "Block Guard");
                            return;
                        }
                    }
                }

                if(playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
            }
            if(collision.tag == "Enemy")
            {

                EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
                CharacterManager enemyCharacterManager = collision.GetComponent<CharacterManager>();
                if (!enemyStats.isDead)
                {
                    BlockingCollider shield = collision.transform.GetComponentInChildren<BlockingCollider>();
                    

                    if (enemyCharacterManager != null)
                    {
                        if (enemyCharacterManager.isParrying)
                        {
                            Debug.Log("Enemy Parrying: " + enemyCharacterManager.isParrying);
                            characterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried", true);
                            return;
                        }
                        else if (shield != null && enemyCharacterManager.isBlocking)
                        {
                            float physicalDamageAfterBlock = currentWeaponDamage - (currentWeaponDamage * shield.blockingPhysicalDamageAbsorption) / 100;
                            if (enemyStats != null)
                            {
                                enemyStats.TakeDamage(Mathf.RoundToInt(physicalDamageAfterBlock), "Block Guard");
                                return;
                            }
                        }
                    }

                    if (enemyStats != null)
                    {
                        enemyStats.TakeDamage(currentWeaponDamage);
                    }
                }

                
            }
        }
    }
}
