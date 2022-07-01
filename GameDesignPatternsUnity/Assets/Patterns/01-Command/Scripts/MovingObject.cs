using System;
using DG.Tweening;
using UnityEngine;

public enum MoveDirection
{
	Forward,
	Backward,
	Left,
	Right
}
[RequireComponent(typeof(Invoker))]
public class MovingObject : MonoBehaviour
{
	//Private Fields
	private Invoker _invoker;
	//Public Fields
	public float moveDistance = 5f;
	public float moveTime = 1f;
	
	#region Unity methods

	private void Start()
	{
		_invoker = gameObject.GetComponent<Invoker>();
	}

	#endregion
	
	#region Private methods
	
	private Vector3 GetMoveDirection(MoveDirection moveDir)
	{
		return moveDir switch
		{
			MoveDirection.Forward => transform.forward,
			MoveDirection.Backward => -transform.forward,
			MoveDirection.Left => -transform.right,
			MoveDirection.Right => transform.right,
			_ => throw new ArgumentOutOfRangeException(nameof(moveDir), moveDir, null)
		};
	}
	
	#endregion
	
	#region Public methods

	public void Move(MoveDirection moveDir)
	{
		transform.DOMove(transform.position + GetMoveDirection(moveDir) * moveDistance, moveTime).SetEase(Ease.Linear);
	}
	
	public void MoveForward()
	{
		_invoker.AddCommand(new MoveCommand(this, moveTime, MoveDirection.Forward, MoveDirection.Backward));
	}
	
	public void MoveBackward()
	{
		_invoker.AddCommand(new MoveCommand(this, moveTime, MoveDirection.Backward, MoveDirection.Forward));
	}
	
	public void MoveLeft()
	{
		_invoker.AddCommand(new MoveCommand(this, moveTime, MoveDirection.Left, MoveDirection.Right));
	}
	
	public void MoveRight()
	{
		_invoker.AddCommand(new MoveCommand(this, moveTime, MoveDirection.Right, MoveDirection.Left));
	}
	
	#endregion
	
}