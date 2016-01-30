using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int CurseLevel { get; set; }
	public int Index { get; set; }

	public void Cursed()
	{
		Debug.Log ("You GOT CURSED");
		CurseLevel++;
		//TODO Determine what to do when you are cursed.
	}

	public void CutEye()
	{
		Debug.LogError ("You cut your eye " + Index.ToString());
		//TODO do things when eyes are cut, play Cut Eye VFX, maybe not
		//Destroy (Eye);
	}

	public void CutHand()
	{
		Debug.LogError ("You cut your hand " + Index.ToString());
		//TODO do things when hands are cut, play Cut Eye VFX, maybe not
		//Destroy (Hand);
	}

	public void CutLeg()
	{
		Debug.LogError ("You cut your leg " + Index.ToString());
		//TODO do things when legs are cut, Play Cut Leg VFX, maybe not
		//Destroy (Leg);
	}
}
