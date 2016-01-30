using UnityEngine;
using System.Collections;

public class BaseContext : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{
		PlayerManager.Singleton.Init ();

		//TODO deal with the canvas.
	}
}
