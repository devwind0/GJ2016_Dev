using UnityEngine;
using System.Collections;

public class OrganTokenScript : MonoBehaviour 
{
	public int organIndex;

	private void OnTriggerEnter(Collider other)
	{
		Player player = other.gameObject.GetComponent<Player> ();
		Debug.LogError ("Enter: " + player.Index);
		PlayerManager.Singleton.EnterTokenArea (player.Index, organIndex, true, this.gameObject);
	}

	private void OnTriggerExit(Collider other)
	{
		Player player = other.gameObject.GetComponent<Player> ();
		Debug.LogError ("Leave: " + player.Index);
		PlayerManager.Singleton.EnterTokenArea (player.Index, organIndex, false, null);
	}
}
