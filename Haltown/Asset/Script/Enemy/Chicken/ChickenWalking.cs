using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChickenWalking : StateMachineBehaviour
{
    List<Transform> points = new List<Transform>();
    float timer;
    NavMeshAgent agent;
    Transform playerTransform;

    float chaseRang = 15;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointObjects = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform pt in pointObjects)
            points.Add(pt);

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(points[Random.Range(0, points.Count)].position);

        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("isWalking", false);

        float distance = Vector3.Distance(animator.transform.position, playerTransform.position);
        if (distance < chaseRang)
            animator.SetBool("isChasing", true);

    }

}
