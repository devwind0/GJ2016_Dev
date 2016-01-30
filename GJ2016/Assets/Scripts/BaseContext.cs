using UnityEngine;
using System.Collections;

public class BaseContext : MonoBehaviour {

	public Transform[] PlayerSpots;

	// Use this for initialization
	void Awake () 
	{
		PlayerManager.Singleton.Init (PlayerSpots);
	}
}
