using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class EnemyManager : CharacterManager
    {
        EnemyLocomotionManager enemyLocomotionManager;
        public bool isPerformingAction;

        [Header("AI Settings")]
        public float detectionRadius;
        //The higher, and lower, respectively these angles are, the greater detection FOV they will have.
        public float maximumDetectionAngle = 50;
        public float minimumDetectionAngle = -50;

        private void Awake()
        {
            enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
        }

        private void Update()
        {
            HandleCurrentAction();
        }

        private void HandleCurrentAction()
        {
            if(enemyLocomotionManager.currentTarget == null)
            {
                if(enemyLocomotionManager.currentTarget == null)
                {
                    enemyLocomotionManager.HandleDetection();
                }
            }
        }
    }
}
