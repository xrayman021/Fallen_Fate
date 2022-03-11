using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class IdleState : State
    {
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            //Look for a potential target.
            //Switch to pursue target state if target is found.
            return this;
        }
    }
}
