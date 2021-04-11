
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Moonrider {

    public class PlayerStateManager : CharacterStateManager // all the logic for states in main player will be placed here
        // because the CharacterStateManager already implements the init we don't have to new Init. 
    {


        [Header("Inputs")]
        public float mouseX;
        public float mouseY;
        public float moveAmount;
        public Vector3 rotateDirection;

        public string locomotionId = "locomotion";
        public string attackStateId = "attackState";
        public override void Init()
        {
            base.Init();

            State locomotion = new State(
                new List<StateAction>() // FixedUpdate
                {
                    new InputManager(this),
                },
                new List<StateAction>() // Update
                {
                },
                new List<StateAction>() // LateUpdate
                {
                }
                );

            State attackState = new State(
               new List<StateAction>() // FixedUpdate
                {
               },
               new List<StateAction>() // Update
                {
               },
               new List<StateAction>() // LateUpdate
                {
               }
               );

            RegisterState(locomotionId, locomotion);
            RegisterState(attackStateId, attackState);

            ChangeState(locomotionId);


        }

        private void FixedUpdate()
        {
            base.FixedTick();
        }

        private void Update()
        {
            base.Tick();
        }

        private void LateUpdate()
        {
            base.LateTick();
        }

    }
}

