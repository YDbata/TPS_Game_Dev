using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
	public void EnterState(Transform enemy, Transform player);
	public void UpdateState();
	public void ExitState();
}
