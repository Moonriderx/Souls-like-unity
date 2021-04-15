using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MoonriderOLD
{

    public class Helper : MonoBehaviour
    {

        [Range(0, 1)]
        public float vertical;

        public bool playAnim;
        public string[] oh_attacks; // we will be storing here one handed attacks
        public string[] th_attacks; // we will be storing here two handed attacks

        public bool twoHanded;
        public bool enableRM; // enable Root motion

        Animator anim;
       

        void Start()
        {
            anim = GetComponent<Animator>();
        }


        void Update()
        {
            enableRM = !anim.GetBool("canMove"); // if you cannot move, then you enable the root motion
            anim.applyRootMotion = enableRM; // animator should be the same as enableRM

            if (enableRM) // if we are attacking we should not be able to attack again until the first attack is finished
                return;


            anim.SetBool("two_handed", twoHanded);

            if (playAnim)
            {
                string targetAnim;

                if (twoHanded) // we are going to check if we are two handed or not
                {
                    int r = Random.Range(0, oh_attacks.Length); // We will be checking for a random oh animation that we will play if we are two handed
                    targetAnim = th_attacks[r]; // it will basically play a different animation
                } 
                else
                {
                    int r = Random.Range(0, th_attacks.Length); // We will be checking for a random oh animation that we will play if we are one handed
                    targetAnim = oh_attacks[r];
                }

                vertical = 0; // Vertical is 0 because if we are attacking (play attack animation) we do not want to move our character while attacking. We are resetting the value

                anim.CrossFade(targetAnim, 0.2f); // fades the animation gradually 
                //anim.SetBool("canMove", false);
                //enableRM = true;
                playAnim = false; 

                // we will play root motion while we are attacking, and then do not play root motion when we are idle
            }

            anim.SetFloat("vertical", vertical); // that will be used to control the vertical axis in our animator blend tree 

            
        }
    }
}