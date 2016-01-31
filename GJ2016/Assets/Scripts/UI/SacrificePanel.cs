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
	private bool isCutHandsButtonDisabled = false;
	private bool isCutEyesButtonDisabled = false;
	private bool isCutLegsButtonDisabled = false;
	// Use this for initialization
	void Start () 
	{
		ToggleSacrificeButton.onClick.AddListener(OnSacrificeButtonClicked);
		CutHandButton.onClick.AddListener(OnCutHandButtonClicked);
		CutEyeButton.onClick.AddListener(OnCutEyeButtonClicked);
		CutLegButton.onClick.AddListener(OnCutLegButtonClicked);
		OptionPanel.SetActive (isPanelActive);
	}

	void Update()
	{
		if ((Input.GetButtonDown ("OpenSacrifice-controller") && Index == 1)
			|| (Input.GetButtonDown ("OpenSacrifice-keyboard") && Index == 0)) 
		{
			isPanelActive = !isPanelActive;
			OptionPanel.SetActive (isPanelActive);
		}
	}

	public void OnSacrificeButtonClicked()
	{
		//if ((Input.GetButtonDown ("OpenSacrifice-controller") || Input.GetButtonDown ("OpenSacrifice-keyboard"))) 
		//{
			isPanelActive = !isPanelActive;
			OptionPanel.SetActive (isPanelActive);
		//}
	}

	public void OnCutHandButtonClicked()
	{
		PlayerManager.Singleton.CutHand (Index);
		CoolDownButtons ();
		CutHandButton.interactable = false;
		CutHandButton.onClick.RemoveListener(OnCutHandButtonClicked);
	}

	public void OnCutEyeButtonClicked()
	{
		PlayerManager.Singleton.CutEye (Index);
		CoolDownButtons ();
		CutEyeButton.interactable = false;
		CutEyeButton.onClick.RemoveListener(OnCutEyeButtonClicked);
	}

	public void OnCutLegButtonClicked()
	{
		PlayerManager.Singleton.CutLeg (Index);
		CoolDownButtons ();
		CutLegButton.interactable = false;
		CutLegButton.onClick.RemoveListener(OnCutLegButtonClicked);
	}

	private void CoolDownButtons(){
		isPanelActive = !isPanelActive;
		OptionPanel.SetActive (isPanelActive);
	}

	private void RecoverButtons(){
		isPanelActive = !isPanelActive;
		OptionPanel.SetActive (isPanelActive);
	}
}
