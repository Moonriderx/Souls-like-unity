using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moonrider {
    public class State
    {
        bool forceExit;
        List<StateAction> fixedUpdateActions;
        List<StateAction> updateActions;
        List<StateAction> LateUpdateActions;

        public State(List<StateAction> fixedUpdateActions, List<StateAction> updateActions, List<StateAction> lateUpdateActions)
        {
            this.fixedUpdateActions = fixedUpdateActions;
            this.updateActions = updateActions;
            this.LateUpdateActions = lateUpdateActions;
        }


        public void FixedTick()
        {
            ExecuteListOfActions(fixedUpdateActions);
        }
        public void Tick()
        {
            ExecuteListOfActions(updateActions);
        }

        public void LateTick()
        {
            ExecuteListOfActions(LateUpdateActions);
            forceExit = false;
        }

        void ExecuteListOfActions(List<StateAction> l) // run all of our actions. Since we've initialized lists above, we would not get NullPointer Ex
        {
            for (int i = 0; i < l.Count; i++)
            {

                if (forceExit)
                    return;

               forceExit = l[i].Execute();
            }
        }

         
    }
}
