using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBool : StateMachineBehaviour
{

    public string boolName;
    public bool status;
    public bool resetOnExit = true;

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.SetBool(boolName, status); // as long as the OnStateUpdate runs (whenever this layer is on this one) it is going to be activating the canMove boolean to true or false

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (resetOnExit)
        animator.SetBool(boolName, !status); // change the status to the oposite when we are leaving the state
    }

}
