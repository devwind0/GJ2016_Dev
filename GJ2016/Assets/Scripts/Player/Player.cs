using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

	public int CurseLevel { get; set; }
	public int Index { get; set; }
	public float HP { get; set; }
	public SacrificePanel panel { get; set; }
	public HPPanel hpPanel { get; set; }
	public Score Score 
	{
		get 
		{
			return score;
		}
	}


	public Transform Canvas;
	public Camera camera;
	public SacrificeVisualEffectHandler SVEHandler;
	private Score score = new Score ();
	private bool alterEntered;
	private bool tokenAreaEntered;
	int tokenIndex = 0;
	private GameObject token;

	private void Start()
	{
		HP = GameConstants.HP_CAP;
		CurseLevel = 1;
	}

	public void Cursed()
	{
		Debug.Log ("You GOT CURSED");
		//TODO Determine what to do when you are cursed.
	}

	public void GetOrgan(int index)
	{
		score.CarryOrgan (index);
		Debug.Log ("You got" + index.ToString ());
	}

	//index 2
	public void CutEye()
	{
		Debug.LogError ("You cut your eye " + Index.ToString());
		//TODO do things when eyes are cut, play Cut Eye VFX, maybe not

		//Destroy (Eye);
		ReduceHP (20);
		score.CutOrgan (2);
		SVEHandler.EnableEyesLostVisualEffect( Index );
		//Make enemy could not see the blood vfx
	}

	public void SendOrgan()
	{
		score.SendOrgan ();
		CheckWinCondition ();
	}

	public void CloseEye()
	{
		SVEHandler.CloseEyesLostVisualEffect (Index);
	}

	public void CloseHands()
	{
		SVEHandler.CloseHandsLostVisualEffect (Index);
	}

	public void CloseLegs()
	{
		SVEHandler.CloseLegsLostVisualEffect (Index);
	}

	//index 0
	public void CutHand()
	{
		Debug.LogError ("You cut your hand " + Index.ToString());
		//TODO do things when hands are cut, play Cut Eye VFX, maybe not
		//Destroy (Hand);

		//SpawnBodyParts ("Prefabs/hand");
		SVEHandler.EnableHandsVisualEffect(Index);
		ReduceHP (20);
		score.CutOrgan (0);
		//SpawnBodyParts ("Prefabs/hand");

	}

	//index 1
	public void CutLeg()
	{
		Debug.LogError ("You cut your leg " + Index.ToString());
		//TODO do things when legs are cut, Play Cut Leg VFX, maybe not
		FirstPersonController controller = this.GetComponent<FirstPersonController>();
		controller.SetWalkingSpeed (2.5f);
		controller.SetRunningSpeed (3.0f);
		ReduceHP (20);
		score.CutOrgan (1);
		//SpawnBodyParts ("Prefabs/leg");
		SVEHandler.EnableLegsVisualEffect(Index);
	}

	private void SpawnBodyParts(string parts)
	{
		GameObject legPrefab = Resources.Load<GameObject> (parts);
		GameObject leg = GameObject.Instantiate (legPrefab);
		leg.transform.localPosition = this.transform.position + this.transform.forward;
		leg.GetComponent<Rigidbody> ().AddForce (this.transform.forward * 600);
	}

	private void ReduceHP(float amount)
	{
		HP = HP - amount;
		hpPanel.SetHP (HP);
		Cursed ();
	}

	private void FixedUpdate()
	{
		if (hpPanel != null) {
			HP = HP - GameConstants.baseHPDecreaseSpeed * (float)CurseLevel * Time.fixedDeltaTime;
			hpPanel.SetHP (HP);
		}
	}

	private void GameOver()
	{
		Application.LoadLevel ("Game_Over_Scene");
	}

	public void EnterAlter(bool isTrue)
	{
		alterEntered = isTrue;
	}

	private void Update()
	{
		if ((Input.GetButtonDown ("CarryOrgan-controller") || Input.GetButtonDown ("CarryOrgan-keyboard"))) 
		{
			Debug.LogError ("Button Pressed");
			if (alterEntered) 
			{
				score.SendOrgan ();
				CheckWinCondition ();
				score.DebugScore ();
			}

			if (tokenAreaEntered)
			{
				score.CarryOrgan (tokenIndex);
				if (token != null) {
					Destroy (token);
				}
			}
		}
	}

	public void EnterTokenArea(bool isTrue, int tokenIndex, GameObject token)
	{
		tokenAreaEntered = isTrue;
		this.tokenIndex = tokenIndex;
		this.token = token;
	}

	private void CheckWinCondition()
	{
		if (score.HasAll ())
			GameOver ();
	}
}
