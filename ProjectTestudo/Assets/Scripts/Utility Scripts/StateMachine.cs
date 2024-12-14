using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	public State currentState;
	public State defaultState;

	[Header("States")]
	Dictionary<string, State> states = new Dictionary<string, State>();


	public Animator animator;

	public void Start()
	{
		animator = GetComponent<animator>();

		states.Add("Idle", IdleState);
        states.Add("Move", MoveState);
        states.Add("Sprint", SprintState);
        states.Add("Crouch", CrouchState);

		ChangeState(IdleState);

    }

    public void Update()
	{
		if (currentState != null)
		{
			currentState.OnUpdate(this);
		}

	}

	public void TryChangeState(State newState)
	{
		if (newState!= null && newState.CanEnter(this))
		{
			ChangeState(newState);
		}
		else
		{
			Debug.Log("State Transition Denied Due To Unmet Conditions.");
		}

	}

	public void ChangeState(State newState)
	{
		if (currentState != null)
		{
			currentState.OnExit(this)
		}

		currentState = newState;

		if (currentState != null)
		{
			currentState.OnEnter(this);
		}

	}

}
