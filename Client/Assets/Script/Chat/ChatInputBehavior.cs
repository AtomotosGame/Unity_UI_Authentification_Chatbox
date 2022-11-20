using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatInputBehavior : MonoBehaviour {

	public ChatClientBehavior chatClient;
	public string inputName { get; set; }
	InputField inField;

	void Start () {
		inField = GetComponent<InputField>();
	}
	
	// Note: End Edit event is called when losing focus (mouse clicks outside input field)
	public void OnEndEdit(string s) {
		if (s.Length < 1) // ignore empty strings
			return;

		if (chatClient.Send(inputName + ": " + s))
			inField.text = "";
			
		// by default, Unity releases focus on the inputfield after pressing enter
		inField.ActivateInputField(); // keep the focus
	}
}
