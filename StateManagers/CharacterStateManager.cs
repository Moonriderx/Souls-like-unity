using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moonrider {
    public abstract class CharacterStateManager : StateManager
    {
        [Header("References")]

        public Animator anim; // every character will have animator
        public new Rigidbody rigidbody;


        [Header("Controller Values")]
        public float vertical;
        public float horizontal;
        public bool lockOn;

        public override void Init()
        {
            anim = GetComponentInChildren<Animator>();
            rigidbody = GetComponentInChildren<Rigidbody>();
        }

        public void PlayTargetAnimations(string targetAnim)
        {
            anim.CrossFade(targetAnim, 0.2f);
        }
    }
}
