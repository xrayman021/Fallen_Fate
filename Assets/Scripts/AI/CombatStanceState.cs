using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class CombatStanceState : State
    {
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            //Check for attack range.
            //Potentially circle player or walk around them.
            //If in attack range return attack state.
            return this;
        }
    }
}
