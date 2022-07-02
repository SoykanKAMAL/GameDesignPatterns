using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EventSender : MonoBehaviour
{
	// All event types
	public static event EventHandler<string> EventHandlerWithParameters;
	public static Action<string> ActionWithParameters;
	public static UnityEvent<string> UnityEventWithParameters = new UnityEvent<string>();
	
	public delegate void DelegateWithParameters(string parameter);
	public static DelegateWithParameters DelegateWithParametersInstance;
	
	//Private Fields
	private string _selectedFirstName;
	private string _selectedLastName;
	
	//Public Fields
	public List<string> firstNames;
	public List<string> lastNames;
	public List<Toggle> firstNameToggles;
	public List<Toggle> lastNameToggles;
	public TMP_Dropdown eventSelectionDropdown;
	
	#region Unity methods

	private void OnEnable()
	{
		RandomizeToggleLabels(firstNameToggles, firstNames);
		RandomizeToggleLabels(lastNameToggles, lastNames);
		SetupEventSelectionDropdown(eventSelectionDropdown);
		
		// Subscribe toggle events
		foreach (var toggle in firstNameToggles)
		{
			toggle.onValueChanged.AddListener(delegate {
				SetupFirstName(toggle.transform.GetComponentInChildren<TextMeshProUGUI>().text);
			});
		}
		
		foreach (var toggle in lastNameToggles)
		{
			toggle.onValueChanged.AddListener(delegate {
				SetupLastName(toggle.transform.GetComponentInChildren<TextMeshProUGUI>().text);
			});
		}
	}
	
	private void OnDisable()
	{
		// Unsubscribe toggle events
		foreach (var toggle in firstNameToggles)
		{
			toggle.onValueChanged.RemoveAllListeners();
		}
		
		foreach (var toggle in lastNameToggles)
		{
			toggle.onValueChanged.RemoveAllListeners();
		}
	}

	#endregion
	
	#region Private methods

	private void SetupEventSelectionDropdown(TMP_Dropdown dropdown)
	{
		dropdown.ClearOptions();
		dropdown.AddOptions(new List<string> {"EventHandler", "Action", "UnityEvent", "Delegate"});
	}
	
	private void RandomizeToggleLabels(List<Toggle> toggleList, IEnumerable<string> inputList)
	{
		// Create a copy of inputList to avoid modifying the original list
		var tempList = new List<string>(inputList);
		
		foreach (var toggle in toggleList)
		{
			var randomName = tempList[Random.Range(0, tempList.Count)];
			toggle.GetComponentInChildren<TextMeshProUGUI>().text = randomName;
			tempList.Remove(randomName);
		}
	}
	
	private void SetupFirstName(string firstName) => _selectedFirstName = firstName;
	
	private void SetupLastName(string lastName) => _selectedLastName = lastName;
	
	#endregion
	
	#region Public methods

	public void SendEvent()
	{
		Debug.Log($"This message is inside Event Sender\nSelected:{_selectedFirstName} {_selectedLastName}");

		switch (eventSelectionDropdown.options[eventSelectionDropdown.value].text)
		{
			case "EventHandler":
				EventHandlerWithParameters?.Invoke(this, $"{_selectedFirstName} {_selectedLastName}");
				break;
			case "Action":
				ActionWithParameters?.Invoke($"{_selectedFirstName} {_selectedLastName}");
				break;
			case "UnityEvent":
				UnityEventWithParameters.Invoke($"{_selectedFirstName} {_selectedLastName}");
				break;
			case "Delegate":
				DelegateWithParametersInstance?.Invoke($"{_selectedFirstName} {_selectedLastName}");
				break;
			case "else":
				Debug.LogError("Please select an event type");
				return;
		}
		
		Debug.Log($"Event sent with {eventSelectionDropdown.options[eventSelectionDropdown.value].text} method");
	}
	
	#endregion
}