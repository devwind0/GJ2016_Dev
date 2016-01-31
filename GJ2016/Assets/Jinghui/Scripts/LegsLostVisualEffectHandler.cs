using UnityEngine;
using System.Collections;

public class LegsLostVisualEffectHandler : MonoBehaviour {

	public Camera camera;

	public GameObject Legs;
	public AudioSource audio;
	public float ShowTime = 6.0f;
	public bool LegsLostVisualEffectFlag
	{
		get{ return m_legsLostVisualEffectFlag; }
		set
		{ 
			m_legsLostVisualEffectFlag = value; 
			if (value) {
				Legs.gameObject.SetActive (true);
				audio.Play();
			}
		}
	}

	private float m_showTimer = 0.0f;
	private bool m_legsLostVisualEffectFlag = false;

	void Start () {
		Legs.gameObject.SetActive (false);
	}


	void Update () {
		if (m_legsLostVisualEffectFlag) {
			UpdateShowLegs ();
		}
	}

	private void UpdateShowLegs(){
		m_showTimer += Time.deltaTime;

		if (m_showTimer < ShowTime) {
			ShowLegs ();
		} 
		else {
			Legs.gameObject.SetActive (false);
			m_legsLostVisualEffectFlag = false;
		}
	}

	private void ShowLegs(){
		Legs.transform.eulerAngles += new Vector3( 0.0f, Time.deltaTime * 70.0f, 0.0f );
	}

	public void SetBloodEffectLayer( int index ){
		Legs.layer = index + 8;

		SetLayerRecursively (Legs, index + 8);
	}

	void SetLayerRecursively(GameObject obj, int newLayer)
	{
		if (null == obj)
		{
			return;
		}

		obj.layer = newLayer;

		foreach (Transform child in obj.transform)
		{
			if (null == child)
			{
				continue;
			}
			SetLayerRecursively(child.gameObject, newLayer);
		}
	}

	public void SetCameraCullingMask(int index ){
		int bloodLayer = ( 1 - index ) + 8;
		camera.cullingMask = ~(1 << bloodLayer);
	}
}