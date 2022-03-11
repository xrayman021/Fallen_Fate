using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class AttackState : State
    {
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            //Select one of our many attacks based on attack scores.
            //If the selected attack is not able to be used becuase of angle or distance, select a new attack.
            //If the attack is viable, stop movement and attack target.
            //Set recovery timer to the attack's recovery time.
            //Return the combat stance.
            //public EnemyAttackAction[] enemyAttacks;
            //public EnemyAttackAction currentAttack;
            return this;
        }
    }
}
