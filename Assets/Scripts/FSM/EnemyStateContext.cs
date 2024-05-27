﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EState
{
	Patrol,
	Chase,
	Shoot,
}
/// <summary>
/// 현재 상태를 보관하고 새로운 상태로 전환해주는 클래스
/// </summary>
public class EnemyStateContext
{
    public IState CurrentState { get; set; }
	private readonly  Transform _controller;
	private readonly  Transform _target;
    
    public EnemyStateContext(Transform enemy, Transform player)
    {
		_controller = enemy;
        _target = player;
    }

	public void Transition(IState state)
	{
		if (CurrentState != null) CurrentState.ExitState();
		CurrentState = state;
		CurrentState.EnterState(_controller, _target);
	}
}
