using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moonrider {
    public abstract class StateAction // This would be our base class for our actions
    {
        public abstract bool Execute();
    }
}
