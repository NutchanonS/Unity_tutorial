using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class PatrolState : StateMachineBehaviour
{
    //-----------patrol------------------------
    float timer;
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;
    //-----------chase player------------------------
    Transform player;
    float chaseRange = 4;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        timer = 0;
        GameObject go = GameObject.FindGameObjectsWithTag("WayPoints")[0];
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        foreach (Transform t in go.transform) { 
            waypoints.Add(t);
        }
        agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        }
        timer += Time.deltaTime;
        if (timer > 8)
        {
            animator.SetBool("IsPatrolling", false);
        }
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
        {
            animator.SetBool("IsChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
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
