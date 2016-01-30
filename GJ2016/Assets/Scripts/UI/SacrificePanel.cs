using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SacrificePanel : MonoBehaviour {

	//My current player index.
	public int Index { get; set; }

	public Button CutHandButton;
	public Button CutLegButton;
	public Button CutEyeButton;
	public Button ToggleSacrificeButton;

	public GameObject OptionPanel;
	private bool isPanelActive = false;
	// Use this for initialization
	void Start () 
	{
		ToggleSacrificeButton.onClick.AddListener(OnSacrificeButtonClicked);
		CutHandButton.onClick.AddListener(OnCutHandButtonClicked);
		CutEyeButton.onClick.AddListener(OnCutEyeButtonClicked);
		CutLegButton.onClick.AddListener(OnCutLegButtonClicked);
		OptionPanel.SetActive (isPanelActive);
	}

	public void OnSacrificeButtonClicked()
	{
		isPanelActive = !isPanelActive;
		OptionPanel.SetActive (isPanelActive);
	}

	public void OnCutHandButtonClicked()
	{
		PlayerManager.Singleton.CutHand (Index);
		CutHandButton.interactable = false;
		CutHandButton.onClick.RemoveListener(OnCutHandButtonClicked);
	}

	public void OnCutEyeButtonClicked()
	{
		PlayerManager.Singleton.CutEye (Index);
		CutEyeButton.interactable = false;
		CutEyeButton.onClick.RemoveListener(OnCutEyeButtonClicked);
	}

	public void OnCutLegButtonClicked()
	{
		PlayerManager.Singleton.CutLeg (Index);
		CutLegButton.interactable = false;
		CutLegButton.onClick.RemoveListener(OnCutLegButtonClicked);
	}
}
