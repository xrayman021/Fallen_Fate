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
        public CriticalDamageCollider backstabCollider;
        public CriticalDamageCollider riposteCollider;

        [Header("Combat Flags")]
        public bool canBeRiposted;
        public bool canBeParried;
        public bool canBeBackstabbed;
        public bool isParrying;
        public bool isBlocking;

        public int pendingCriticalDamage;
    }
}
