using System;
using UnityEngine;

public abstract class State : ScriptableObject
{
	public string stateName;

	public virtual bool CanEnter(StatMachine stateMachine)
	{
		return true;
	}
	public abstract void OnEnter(StateMachine stateMachine);
	public abstract void OnUpdate(StateMachine stateMachine);
	public abstract void OnFixedUpdate(StateMachine stateMachine);
	public abstract void OnExit(StateMachine stateMachine);
}
