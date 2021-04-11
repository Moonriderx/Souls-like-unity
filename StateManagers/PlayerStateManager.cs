using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Moonrider {

    public class PlayerStateManager : CharacterStateManager // all the logic for states in main player will be placed here
        // because the CharacterStateManager already implements the init we don't have to new Init. 
    {

        public override void Init()
        {
            base.Init();

            State locomotion = new State(
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

            RegisterState("locomotion", locomotion);
            RegisterState("attackState", attackState);

            ChangeState("locomotion");


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
