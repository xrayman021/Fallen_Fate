using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class PlayerAttacker : MonoBehaviour
    {
        AnimatorHandler animatorHandler;

        private void Start()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }
        public void HandleLightAttack(WeaponItem weapon)
        {
            animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
        }
    }
}
