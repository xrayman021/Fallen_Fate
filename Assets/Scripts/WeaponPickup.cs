using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class WeaponPickup : Interactable
    {
        public WeaponItem weapon;

        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            //Pick up item and add to inventory.

        }

        private void PickUpItem(PlayerManager playerManager)
        {
            PlayerInventory playerInventory;
            PlayerLocomotion playerLocomotion;
            AnimatorHandler animatorHandler;
            playerInventory = playerManager.GetComponent<PlayerInventory>();
            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();

            playerLocomotion.rigidbody.velocity = Vector3.zero; //Stop while picking up object.
            animatorHandler.PlayTargetAnimation("Pick Up Item", true); //Plays looting animation.
            playerInventory.weaponsInventory.Add(weapon);
        }
    }
}
