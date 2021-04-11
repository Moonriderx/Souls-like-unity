<<<<<<< HEAD
=======

>>>>>>> 46c503bad8c61098f55441a656c03ef0eb163dc6
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

        [Header("States")]
        public bool isGrounded;

        [Header("References")]
        public new Transform camera;


        [Header("Movement Stats")]
        public float frontRayOffset = .5f;
        public float movementSpeed = 1;
        public float adaptSpeed = 1;
        public float rotationSpeed = 10;

<<<<<<< HEAD
        [HideInInspector]
        public LayerMask ignoreForGroundCheck;

        [HideInInspector]
        public const string locomotionId = "locomotion";
        [HideInInspector]
        public const string attackStateId = "attackState";
        public override void Init()
        {
            base.Init();

            State locomotion = new State(
                new List<StateAction>() // FixedUpdate
                {
                    
                    new MovePlayerCharacter(this),

                },
                new List<StateAction>() // Update
                {
                    new InputManager(this),
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

            ignoreForGroundCheck = ~(1 << 9 | 1 << 10);


        }

        private void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;

            base.FixedTick();
        }

        private void Update()
        {
            delta = Time.deltaTime;

            base.Tick();
        }

        private void LateUpdate()
        {
            base.LateTick();
        }

    }
}
=======
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

>>>>>>> 46c503bad8c61098f55441a656c03ef0eb163dc6
