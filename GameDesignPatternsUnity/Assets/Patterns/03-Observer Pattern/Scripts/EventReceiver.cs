using System;
using TMPro;
using UnityEngine;

namespace ObserverPattern
{
	public class EventReceiver : MonoBehaviour
	{
		//Private Fields
	
		//Public Fields
		public TextMeshProUGUI outputText;

		#region Unity methods

		private void OnEnable()
		{
			EventSender.ActionWithParameters += ChangeOutputText;
		
			// Anonymous function as event handler => use only when you don't need to unsubscribe later
			//EventSender.EventHandlerWithParameters += delegate(object sender, string s) { ChangeOutputText(s); };
			EventSender.EventHandlerWithParameters += ChangeOutputText;
		
			EventSender.UnityEventWithParameters.AddListener(ChangeOutputText);
		
			EventSender.DelegateWithParametersInstance += ChangeOutputText;
		}

		private void OnDisable()
		{
			EventSender.ActionWithParameters -= ChangeOutputText;
		}

		#endregion

		#region Private methods

		private void ChangeOutputText(string text) => outputText.text = text;
	
		private void ChangeOutputText(object sender, string text) => outputText.text = text;
	
		#endregion
	}
}