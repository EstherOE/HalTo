using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenIdle : StateMachineBehaviour
{
    float timer;
    Transform playerTransform;

    float chaseRang = 15;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        timer += Time.deltaTime;
        if (timer > 5)
            animator.SetBool("isWalking", true);

        float distance = Vector3.Distance(animator.transform.position, playerTransform.position);
        if (distance < chaseRang)
            animator.SetBool("isChasing", true);
    }

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
