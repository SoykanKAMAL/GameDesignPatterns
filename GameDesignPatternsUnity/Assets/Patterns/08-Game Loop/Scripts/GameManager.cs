using System;
using UnityEngine;

namespace GameLoopPattern
{
	public class GameManager : MonoBehaviour
	{
		//Private Fields
		private GameLoopVariableTimeStep _gameLoopVariableTimeStep;
		private GameLoopFixedTimeStep _gameLoopFixedTimeStep;
		private WhileLoop whileLoop;
		//Public Fields
		
	
		#region Unity methods

		private void Start()
		{
			Time.timeScale = 0.1f;
			
			
			
			whileLoop = new WhileLoop();
		}

		#endregion
	
		#region Private methods
    
		[ContextMenu("CreateGameLoopVariableTimeStep")]
		private void CreateGameLoopVariableTimeStep()
		{
			DestroyLoops();
			
			_gameLoopVariableTimeStep = new GameLoopVariableTimeStep();
			StartCoroutine(_gameLoopVariableTimeStep.StartLoop());
		}
		
		[ContextMenu("CreateGameLoopFixedTimeStep")]
		private void CreateGameLoopFixedTimeStep()
		{
			DestroyLoops();
			
			_gameLoopFixedTimeStep = new GameLoopFixedTimeStep();
			StartCoroutine(_gameLoopFixedTimeStep.StartLoop());
		}
		
		[ContextMenu("CreateWhileLoop")]
		private void CreateWhileLoop()
		{
			DestroyLoops();
			
			whileLoop = new WhileLoop();
			StartCoroutine(whileLoop.StartLoop());
		}
		
		[ContextMenu("DestroyLoops")]
		private void DestroyLoops()
		{
			StopAllCoroutines();
			
			_gameLoopVariableTimeStep = null;
			
			_gameLoopFixedTimeStep = null;
			
			whileLoop = null;
		}
		
		#endregion
	}
}
