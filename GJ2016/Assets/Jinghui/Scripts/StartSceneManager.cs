﻿using UnityEngine;
using System.Collections;

public class StartSceneManager : MonoBehaviour {

	public void OnStartButtonClick() {
		Application.LoadLevel ("Initial");
	}

	public void OnCreditsButtonClick(){
		Application.LoadLevel ("CreditsScene");
	}

	public void OnQuitButtonClick(){
		Application.Quit ();
	}
}
