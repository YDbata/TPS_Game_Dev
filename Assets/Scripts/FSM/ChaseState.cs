using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : MonoBehaviour,IState
{
	private Animator animator;
	private NavMeshAgent agent;

	private Enemy currentEnemy;
	private Transform target;
	public void EnterState(Enemy enemy)
	{
		if (!animator) animator = gameObject.GetAroundComponent<Animator>();
		if (!agent) agent = gameObject.GetAroundComponent<NavMeshAgent>();

		currentEnemy = enemy;
		target = enemy.Target;

		animator.SetBool("Walk", false);
		animator.SetBool("AimRun", true);
		animator.SetBool("Shoot", false);
		animator.SetBool("Dead", false);
	}

	public void UpdateState()
	{
		agent.SetDestination(target.position);
	}

	public void ExitState()
	{
		animator.SetBool("Walk", false);
		animator.SetBool("AimRun", false);
		animator.SetBool("Shoot", false);
		animator.SetBool("Dead", false);
	}
}
