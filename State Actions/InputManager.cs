using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moonrider {
    public class InputManager : StateAction
    {
        PlayerStateManager s;

        // Triggers & Bumpers
        bool Rb, Rt, Lb, Lt, isAttacking, b_Input, y_Input, x_Input, inventoryInput, leftArrow, rightArrow, upArrow, downArrow;


        public InputManager(PlayerStateManager states)
        {
            s = states;
        }

        public override bool Execute()
        {
            bool retVal = false;

            s.horizontal = Input.GetAxis("Horizontal");
            s.vertical = Input.GetAxis("Vertical");
            Rb = Input.GetButton("RB");
            Rt = Input.GetButton("RT");
            Lb = Input.GetButton("LB");
            Lt = Input.GetButton("LT");

            inventoryInput = Input.GetButton("Inventory");

            b_Input = Input.GetButton("B");
            y_Input = Input.GetButtonDown("Y");
            x_Input = Input.GetButton("X");

            leftArrow = Input.GetButton("Left");
            rightArrow = Input.GetButton("Right");
            upArrow = Input.GetButton("Up");
            downArrow = Input.GetButton("Down");
            s.mouseX = Input.GetAxis("Mouse X");
            s.mouseY = Input.GetAxis("Mouse Y");

            s.moveAmount = Mathf.Clamp01(Mathf.Abs(s.horizontal) + Mathf.Abs(s.vertical));

            retVal = HandleAttacking();
            

            return retVal;
        }

        bool HandleAttacking()
        {

            if (Rb || Rt || Lb || Lt)
            {
                //isAttacking = true;
            }

            // Here we can place a logic that interrupts attack

            if (y_Input)
            {
                isAttacking = false;
            }

            if (isAttacking)
            {
                // find the actual animations from the items etc...
                //Then play animation
                //s.PlayTargetAnimations("");
                //s.ChangeState(s.attackStateId);
            }
            return isAttacking;

        }

      
    }
}
