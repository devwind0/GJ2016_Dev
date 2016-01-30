using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

	public int CurseLevel { get; set; }
	public int Index { get; set; }
	public float HP { get; set; }
	public SacrificePanel panel { get; set; }
	public HPPanel hpPanel { get; set; }

	public Transform Canvas;

	private void Start()
	{
		HP = GameConstants.HP_CAP;
		CurseLevel = 1;
	}

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
		SpawnBodyParts ("Prefabs/hand");
	}

	public void CutLeg()
	{
		Debug.LogError ("You cut your leg " + Index.ToString());
		//TODO do things when legs are cut, Play Cut Leg VFX, maybe not
		FirstPersonController controller = this.GetComponent<FirstPersonController>();
		controller.SetWalkingSpeed (1.0f);

		SpawnBodyParts ("Prefabs/leg");
	}

	private void SpawnBodyParts(string parts)
	{
		GameObject legPrefab = Resources.Load<GameObject> (parts);
		GameObject leg = GameObject.Instantiate (legPrefab);
		leg.transform.localPosition = this.transform.position + this.transform.forward;
		leg.GetComponent<Rigidbody> ().AddForce (this.transform.forward * 600);
	}

	private void FixedUpdate()
	{
		if (hpPanel != null) {
			HP = HP - GameConstants.baseHPDecreaseSpeed * (float)CurseLevel * Time.fixedDeltaTime;
			hpPanel.SetHP (HP);
		}
	}
}
