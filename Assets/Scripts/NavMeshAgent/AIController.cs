using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mali.Tools;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [Header("Chase Parameters")]
    public NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [ReadOnly] public Transform target;
    
    [Header("Attack Parameters")]
    [SerializeField] [Tooltip("How long the AI waits before doing another attack")] 
    private float attackCooldown;
    [SerializeField] private float attackRange;
    
    [Header("Patrol Parameters")]
    [SerializeField, Range(0, 10)] private float patrolSpeed;
    [SerializeField] private Transform[] waypoints;
    
    private StateMachine stateMachine;
    

    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new ChaseState(this, animator));
        
        agent.velocity = Vector3.zero;
    }

    void Update()
    {
        stateMachine.ExecuteState();
        HandleTransition();
    }

    public void HandleTransition()
    {
        bool canSeePlayer = true;

        if (stateMachine.currentState is ChaseState)
        {
            //if(player is close enough)
            // go to attack state
        }

        if (canSeePlayer)
        {
            stateMachine.ChangeState(new ChaseState(this, animator));
        }
        else
        {
            //Change state to patrol
            //stateMachine.ChangeState(new PatrolState(this, animator));
        }
    }


    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

}
