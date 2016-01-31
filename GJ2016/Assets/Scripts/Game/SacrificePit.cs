using UnityEngine;
using System.Collections;

public class SacrificePit : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		Player player = other.gameObject.GetComponent<Player> ();
		Debug.LogError ("Enter: " + player.Index);
		PlayerManager.Singleton.EnterAlter (player.Index, true);
	}

	private void OnTriggerExit(Collider other)
	{
		Player player = other.gameObject.GetComponent<Player> ();
		Debug.LogError ("Leave: " + player.Index);
		PlayerManager.Singleton.EnterAlter (player.Index, false);
	}
}
