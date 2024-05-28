using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : MonoBehaviour,IState
{
	private Animator animator;
	private NavMeshAgent agent;
    
	private Transform target;
    //private PlayerController _playerController;
	public void EnterState(Transform enemy, Transform player)
	{
		if (!animator) animator = gameObject.GetAroundComponent<Animator>();
		if (!agent) agent = gameObject.GetAroundComponent<NavMeshAgent>();
        //if (!_playerController) _playerController = gameObject.GetAroundComponent<PlayerController>();
        
		target = player;

		animator.SetFloat("Speed", 8);
		animator.SetBool("Shoot", false);
		animator.SetBool("Dead", false);
        agent.speed = 5;
    }

	public void UpdateState()
	{
		agent.SetDestination(target.position);
        
	}

	public void ExitState()
	{
		animator.SetFloat("Speed", 3);
		animator.SetBool("Shoot", false);
		animator.SetBool("Dead", false);
        agent.speed = 3.5f;
    }
}
