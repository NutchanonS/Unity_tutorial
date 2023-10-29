using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Woft_mono_animation : MonoBehaviour
{
    //-----------patrol------------------------
    public float timer;
    //List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;
    //-----------chase player------------------------
    Transform player;
    float chaseRange = 4;
    //--------animator------------------------
    Animator animator;
    bool IsEnterPatrol = false;
    bool IsInpatrol = false;
    private AnimatorStateInfo cachedAnimatorStateInfo;

    public List<Vector3> waypoints = new List<Vector3>(4);

    private void Awake()
    {
        Vector3 pos1 = transform.position;
        pos1.x -= 5.0f;
        Vector3 pos2 = transform.position;
        pos2.x += 5.0f;
        Vector3 pos3 = transform.position;
        pos3.z -= 5.0f;
        Vector3 pos4 = transform.position;
        pos4.z += 5.0f;
        waypoints.Add(pos1);
        waypoints.Add(pos2);
        waypoints.Add(pos3);
        waypoints.Add(pos4);
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        handleAnimator();
    }
    void handleAnimator()
    {
        //IsInpatrol = this.animator.GetCurrentAnimatorStateInfo(0).IsName("PatrolState");
        IsInpatrol = (animator.GetBool("IsPatrolling") && !animator.GetBool("IsChasing"));
        //Debug.Log("-----------" + animator.GetBool("IsPatrolling").ToString() + animator.GetBool("IsChasing").ToString());
          

        // on state enter
        if (IsInpatrol && IsEnterPatrol==false)
        {
            IsEnterPatrol = true;
            agent.speed = 1.5f;
            timer = 0;
            // Avoid any reload.
        }

        // on state update
        if (IsInpatrol && IsEnterPatrol == true)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)]);
            }
            timer += Time.deltaTime;
            if (timer > 8)
            {
                animator.SetBool("IsPatrolling", false);
                IsEnterPatrol = false;
            }
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance < chaseRange)
            {
                animator.SetBool("IsChasing", true);
                IsEnterPatrol = false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        foreach (Vector3 v in waypoints)
        {
            //waypoints.Add(t);
            Gizmos.DrawWireSphere(v, 2);
        }
    }
}
