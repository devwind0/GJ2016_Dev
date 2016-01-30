using UnityEngine;
using System.Collections;

public class BaseContext : MonoBehaviour {

	public Transform[] PlayerSpots;

	// Use this for initialization
	void Start () 
	{
		PlayerManager.Singleton.Init (PlayerSpots);
	}
}
