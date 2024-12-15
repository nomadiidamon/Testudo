using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMachine : MonoBehaviour
{
	public State currentState;
	public State defaultState;

	[Header("States")]
	public Dictionary<string, State> states = new Dictionary<string, State>();
	public IdleState idle;
	public MoveState move;



	public Animator animator;

	public void Start()
	{
		animator = GetComponent<Animator>();

		states.Add("Idle", idle);
        states.Add("Move", move);
        //states.Add("Sprint", SprintState);
        //states.Add("Crouch", CrouchState);

		ChangeState(idle);

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
			currentState.OnExit(this);
		}

		currentState = newState;

		if (currentState != null)
		{
			currentState.OnEnter(this);
		}

	}

}
