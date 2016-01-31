using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SacrificePanel : MonoBehaviour {

	//My current player index.
	public int Index { get; set; }
	public int selectionIndex = 0;
	public Button CutHandButton;
	public Button CutLegButton;
	public Button CutEyeButton;
	public Button ToggleSacrificeButton;
	public Transform Arrow;


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
		Arrow.gameObject.SetActive (isPanelActive);
		SetArrow (selectionIndex);
	}

	void Update()
	{
		if ((Input.GetButtonDown ("OpenSacrifice-controller") && Index == 1)
			|| (Input.GetButtonDown ("OpenSacrifice-keyboard") && Index == 0)) 
		{
			isPanelActive = !isPanelActive;
			OptionPanel.SetActive (isPanelActive);
			Arrow.gameObject.SetActive (isPanelActive);
		}

		if (isPanelActive) 
		{
			if ((Input.GetButtonDown ("CarryOrgan-controller") && Index == 1)
			    || (Input.GetButtonDown ("CarryOrgan-keyboard") && Index == 0)) 
			{
				switch (selectionIndex) 
				{
				case 0:
					OnCutLegButtonClicked ();
					break;
				case 1:
					OnCutHandButtonClicked ();
					break;
				case 2:
					OnCutEyeButtonClicked ();
					break;
				}
			}

			if (Input.GetKeyDown (KeyCode.UpArrow) ||
				Input.GetButtonDown ("Axis-controller")) 
			{
				selectionIndex--;
				if (selectionIndex < 0) {
					selectionIndex = 2;
				}
				SetArrow (selectionIndex);
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				selectionIndex++;
				if (selectionIndex > 2) {
					selectionIndex = 0;
				}
				SetArrow (selectionIndex);
			}
		}
	}

	private void SetArrow(int selectionIndex)
	{
		RectTransform rect = Arrow as RectTransform;
		switch (selectionIndex) 
		{
		case 0:
			rect.anchoredPosition3D = new Vector3 (-31.4f, -24f, 0);
			break;
		case 1:
			rect.anchoredPosition3D = new Vector3 (-31.4f, -66.51f, 0);
			break;
		case 2:
			rect.anchoredPosition3D = new Vector3 (-31.4f, -108.52f, 0);
			break;
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
		Arrow.gameObject.SetActive (isPanelActive);
	}

	private void RecoverButtons(){
		isPanelActive = !isPanelActive;
		OptionPanel.SetActive (isPanelActive);
		Arrow.gameObject.SetActive (isPanelActive);
	}
}
