using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Moonrider
{
    public abstract class StateManager : MonoBehaviour // we would need to create another class that is instance of this class

    {
        State currentState;
        Dictionary<string, State> allStates = new Dictionary<string, State>();

        [HideInInspector]
        public Transform mTransform;

        private void Start()
        {
            mTransform = this.transform;
            Init();
        }

        public abstract void Init();

        public void Tick()
        {
            if (currentState == null)

                return;

            currentState.Tick();

        }

        public void FixedTick()
        {
            if (currentState == null)

                return;

            currentState.FixedTick();

        }

        public void LateTick()
        {
            if (currentState == null)

                return;

            currentState.LateTick();

        }

        public void ChangeState(string targetId)
        {
            if (currentState != null)
            {
                //Run or exit actions on currentState
            }

            State targetState = GetState(targetId); // run on enter actions

            currentState = targetState;
        }

        State GetState(string targetId)
        {
            allStates.TryGetValue(targetId, out State retVal);
            return retVal;
        }
        protected void RegisterState(string stateId, State state) // We can ovveride it from stateManager
        {
            allStates.Add(stateId, state);
        }
        

        }


    }
