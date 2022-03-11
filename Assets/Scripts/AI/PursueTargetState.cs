using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class PursueTargetState : State
    {
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            //Chase the target.
            //If within attack range, switch to combat stance state.
            return this;
        }
    }
}
