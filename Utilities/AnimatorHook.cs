using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Moonrider
{

    public class AnimatorHook : MonoBehaviour
    {
        CharacterStateManager states; // We need a reference of the stateManager
     public virtual void Init(CharacterStateManager stateManager)
        {
            states = (CharacterStateManager)stateManager;
        }

        public void OnAnimatorMove() // it runs every time when we have a new value on the animator
        {
            OnAnimatorMoveOvveride();


        }

        public virtual void OnAnimatorMoveOvveride()
        {
            if (states.useRootMotion == false)
                return;

            if (states.isGrounded && states.delta > 0)
            {
                Vector3 v = (states.anim.deltaPosition) / states.delta;
                v.y = states.rigidbody.velocity.y;
                states.rigidbody.velocity = v;
            }
        }

    }
}