using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EState
{
	Patrol,
	Chase,
	Shoot,
}
/// <summary>
/// ���� ���¸� �����ϰ� ���ο� ���·� ��ȯ���ִ� Ŭ����
/// </summary>
public class EnemyStateContext
{
    public IState CurrentState { get; set; }
	private readonly Enemy _controller;
    public EnemyStateContext(Enemy enemy)
    {
		_controller = enemy;
	}

	public void Transition(IState state)
	{
		if (CurrentState != null) CurrentState.ExitState();
		CurrentState = state;
		CurrentState.EnterState(_controller);
	}
}
