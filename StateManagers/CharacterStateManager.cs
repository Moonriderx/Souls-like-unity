using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moonrider {
    public class CharacterStateManager : StateManager
    {
        [Header("References")]

        public Animator anim; // every character will have animator
        public new Rigidbody rigidbody;


        [Header("Controller Values")]
        public float vertical;
        public float horizontal;

        public override void Init()
        {
            anim = GetComponentInChildren<Animator>();
            rigidbody = GetComponentInChildren<Rigidbody>();
        }
    }
}
