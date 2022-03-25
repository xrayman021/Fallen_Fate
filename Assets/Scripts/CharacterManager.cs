using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class CharacterManager : MonoBehaviour
    {
        [Header("Lock On Transform")]
        public Transform lockOnTransform;

        [Header("Combat Colliders")]
        public BoxCollider backstabBoxCollider;
        public BackstabCollider backstabCollider;

        public int pendingCriticalDamage;
    }
}
