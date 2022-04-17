using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    [CreateAssetMenu(menuName = "AI/Enemy Actions/Attack Action")]
    public class EnemyAttackAction : EnemyActions
    {
        public bool canCombo;

        public int attackScore = 3;
        public float recoveryTime = 2;

        public float maximumAttackAngle = 35;
        public float minimumAttackAngle = -35;

        public float minimumDistanceNeededToAttack = 1;
        public float maximumDistanceNeededToAttack = 3;
    }
}
