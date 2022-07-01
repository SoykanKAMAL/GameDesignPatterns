using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	//Private Fields
	private Queue<GameObject> commandUIs = new Queue<GameObject>();
	private Stack<GameObject> redoCommandUIs = new Stack<GameObject>();
	//Public Fields
	public GameObject commandUIPrefab;
	public Transform commandUIParent;
	public Transform redoCommandUIParent;
	public List<MoveButton> moveButtons;
	public TextMeshProUGUI currentExecutingCommandText;
	public Button undoButton;

	[Serializable]
	public struct MoveButton
	{
		public MoveDirection direction;
		public GameObject button;
		public Color color;
	}
	
	
	#region Unity methods

	private void Start()
	{
		foreach (var moveButton in moveButtons)
		{
			moveButton.button.GetComponent<Image>().color = moveButton.color;
		}
	}

	private void OnEnable()
	{
		MoveCommand.OnCommandCreated += OnCommandCreated_UIManager;
		MoveCommand.OnCommandExecuted += OnCommandExecuted_UIManager;
		MoveCommand.OnCommandUndone += OnCommandUndone_UIManager;
		Invoker.OnCurrentCommandChanged += OnCurrentCommandChanged_UIManager;
	}
	
	private void OnDisable()
	{
		MoveCommand.OnCommandCreated -= OnCommandCreated_UIManager;
		MoveCommand.OnCommandExecuted -= OnCommandExecuted_UIManager;
		MoveCommand.OnCommandUndone -= OnCommandUndone_UIManager;
		Invoker.OnCurrentCommandChanged -= OnCurrentCommandChanged_UIManager;
	}

	#endregion
	
	#region Private methods

	private void OnCommandCreated_UIManager(ICommand command)
	{
		var commandUiCopy = SetupCommandUI(command, commandUIParent);
		commandUIs.Enqueue(commandUiCopy);
	}
	
	private void OnCommandExecuted_UIManager(ICommand command)
	{
		var commandUiCopy = SetupCommandUI(command, redoCommandUIParent);
		redoCommandUIs.Push(commandUiCopy);
		
		Destroy(commandUIs.Dequeue().gameObject);
	}
	
	private void OnCommandUndone_UIManager(ICommand command)
	{
		Destroy(redoCommandUIs.Pop().gameObject);
	}
	
	private GameObject SetupCommandUI(ICommand command, Transform parent)
	{
		var commandUiCopy = Instantiate(commandUIPrefab, parent);
		commandUiCopy.transform.Find("CommandName").GetComponent<TextMeshProUGUI>().text = command.ToString();
		commandUiCopy.transform.GetComponent<Image>().color = FindButtonColor(command.GetMoveDirection());
		return commandUiCopy;
	}
	
	private Color FindButtonColor(MoveDirection direction)
	{
		foreach (var moveButton in moveButtons)
		{
			if (moveButton.direction == direction)
			{
				return moveButton.color;
			}
		}
		return Color.white;
	}
	
	private void OnCurrentCommandChanged_UIManager(ICommand? command)
	{
		if (command == null)
		{
			currentExecutingCommandText.text = "No Commands Being Executed";
			undoButton.interactable = true;
			return;
		}
		currentExecutingCommandText.text = command.ToString();
		undoButton.interactable = false;
	}

	#endregion
	
	#region Public methods
    
	#endregion
}