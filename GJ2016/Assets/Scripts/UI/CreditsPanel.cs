using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsPanel : MonoBehaviour {

	public Button quitButton;

	private void Start()
	{
		quitButton.onClick.AddListener(OnQuitClicked);
	}

	private void OnQuitClicked()
	{
		quitButton.onClick.RemoveListener(OnQuitClicked);
		Application.LoadLevel ("Start_Scene");
	}
}
