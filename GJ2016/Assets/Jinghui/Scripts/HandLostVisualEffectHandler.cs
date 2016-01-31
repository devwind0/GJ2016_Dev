using UnityEngine;
using System.Collections;

public class HandLostVisualEffectHandler : MonoBehaviour {

	public Camera camera;

	public GameObject Hands;
	public AudioSource audio;
	public float ShowTime = 6.0f;
	public bool HandsLostVisualEffectFlag
	{
		get{ return m_handsLostVisualEffectFlag; }
		set
		{ 
			m_handsLostVisualEffectFlag = value; 
			if (value) {
				Hands.gameObject.SetActive (true);
				audio.Play();
			}
		}
	}

	private float m_showTimer = 0.0f;
	private bool m_handsLostVisualEffectFlag = false;

	void Start () {
		Hands.gameObject.SetActive (false);
	}


	void Update () {
		if (m_handsLostVisualEffectFlag) {
			UpdateShowHands ();
		}
	}

	private void UpdateShowHands(){
		m_showTimer += Time.deltaTime;

		if (m_showTimer < ShowTime) {
			ShowHands ();
		} 
		else {
			Hands.gameObject.SetActive (false);
			m_handsLostVisualEffectFlag = false;
		}
	}

	private void ShowHands(){
		Hands.transform.eulerAngles += new Vector3( 0.0f, Time.deltaTime * 70.0f, 0.0f );
	}

	public void SetBloodEffectLayer( int index ){
		Hands.layer = index + 8;

		SetLayerRecursively (Hands, index + 8);
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