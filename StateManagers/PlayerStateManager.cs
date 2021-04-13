<<<<<<< HEAD
﻿using System.Collections;
=======
using System.Collections;
>>>>>>> 9afc7dc63f17d1c598731af49327e59185b8c7d3
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
       

        [Header("References")]
        public new Transform camera;
        public Transform target; // drag and drop the enemy


        [Header("Movement Stats")]
        public float frontRayOffset = .5f;
        public float movementSpeed = 1;
        public float adaptSpeed = 1;
        public float rotationSpeed = 10;

        [HideInInspector]
        public LayerMask ignoreForGroundCheck;

        [HideInInspector]
        public  string locomotionId = "locomotion";
        [HideInInspector]
        public  string attackStateId = "attackState";
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

            locomotion.onEnter = DisableRootMotion;

            State attackState = new State(
               new List<StateAction>() // FixedUpdate
               {
               },
               new List<StateAction>() // Update
                {
                   new MonitorInteractingAnimation(this, "isInteracting" ,locomotionId),
               },
               new List<StateAction>() // LateUpdate
               {
               }
               );

            attackState.onEnter = EnableRootMotion;

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


        #region State Events
        void DisableRootMotion()
        {
            useRootMotion = false;
        }

        void EnableRootMotion()
        {
            useRootMotion = true;
        }

        #endregion


    }
}
