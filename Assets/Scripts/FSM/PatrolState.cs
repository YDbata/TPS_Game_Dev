using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : MonoBehaviour , IState
{
	[SerializeField] Transform[] wayPoints;
	[SerializeField] int currentWayPoint = 0;
	[SerializeField] float walkingPointRadius = 2;
	[SerializeField] float standPointRadius = 1;
	public float walkSpeed = 3;

	private Transform currentEnemy;
	private Animator animator;
	private NavMeshAgent agent;

	public void EnterState(Transform enemy, Transform target)
	{
		if(!animator) animator = gameObject.GetAroundComponent<Animator>();
		if (!agent) agent = gameObject.GetAroundComponent<NavMeshAgent>();

		currentEnemy = enemy;

		animator.SetBool("Walk", true);
		animator.SetBool("AimRun", false);
		animator.SetBool("Shoot", false);
		animator.SetBool("Dead", false);
	}

	public void UpdateState()
	{	
		if(wayPoints.Length == 1)
        {
			if (Vector3.Distance(wayPoints[currentWayPoint].position, currentEnemy.position)
			< standPointRadius)
            {
				
				currentEnemy.rotation = Quaternion.Lerp(currentEnemy.rotation, wayPoints[currentWayPoint].rotation, Time.deltaTime*5);
				
				if (walkSpeed > 0.01)
                {
					walkSpeed = Mathf.Lerp(walkSpeed, 0.00f, 3 * Time.deltaTime);
                }
				else
					walkSpeed = 0;

				animator.SetFloat("Speed", walkSpeed);

			}

		}

		else if (Vector3.Distance(wayPoints[currentWayPoint].position, currentEnemy.transform.position)
			< walkingPointRadius)
		{
			currentWayPoint++;
			if (currentWayPoint >= wayPoints.Length)
			{
				currentWayPoint = 0;
			}
		}
		agent.SetDestination(wayPoints[currentWayPoint].position);
	}

	public void ExitState()
	{
		animator.SetBool("Walk", false);
		animator.SetFloat("Speed", walkSpeed, 0.5f, Time.deltaTime);
		animator.SetBool("AimRun", false);
		animator.SetBool("Shoot", false);
		animator.SetBool("Dead", false);
	}
}
