using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CH
{
    public class AnimatorManager : MonoBehaviour
    {
        public Animator anim;
        public void PlayTargetAnimation(string targetAnim, bool isInteracting)
        {
            anim.applyRootMotion = isInteracting;
            anim.SetBool("isInteracting", isInteracting);
            anim.CrossFade(targetAnim, 0.2f);
        }

        public virtual void TakeCriticalDamageAnimationEvent()
        {

        }
    }
}
