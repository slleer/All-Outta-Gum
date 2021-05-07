using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAnimationScript : StateMachineBehaviour
{
    public bool dead = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("walk"))
            animator.SetBool("walk", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(((Player.inst.gameObject.transform.position - animator.transform.position).sqrMagnitude < 75) && !dead)
        {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
            //animator.SetFloat("MoveSpeed", 0f);

        }
        else if(!dead)
        {
            animator.SetFloat("MoveSpeed", 5f);
        }
        if(animator.gameObject.GetComponent<Target>().health <= 0)
        {
            dead = true;
            animator.ResetTrigger("Attack");
            animator.SetFloat("MoveSpeed", 0f);
            animator.ResetTrigger("Dead");
            animator.SetTrigger("Dead");
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
