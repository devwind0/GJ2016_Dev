using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class EyesLostVisualEffect : MonoBehaviour {

	public Blur blurEffect;
	public NoiseAndGrain noiseEffect;
	public VignetteAndChromaticAberration vignetteEffect;
	public GameObject bloodPartical;
	public AudioSource audio;

	public bool VisualEffectFlay{
		get{ return m_visualEffectFlag; }
		set{ 
			m_visualEffectFlag = value; 
			if (value) EnableVisualEffect ();
		}
	}

	public float blurFlickTime = 4.0f;
	public float noiseFlickTime = 2.0f;

	private float noiseTimer = 0.0f;
	private float blurTimer = 0.0f;

	private bool m_visualEffectFlag = false;

	void Start () {
		DisableVisualEffect ();
	}

	void Update () {
		if (m_visualEffectFlag) {
			UpdateVisualEffect ();
		}
		else {
			DisableVisualEffect ();
		}
	}

	private void UpdateVisualEffect(){
		noiseTimer += Time.deltaTime;
		if (noiseTimer < noiseFlickTime) 
		{
			noiseEffect.intensityMultiplier = noiseTimer * 4.0f;
			vignetteEffect.intensity = noiseTimer * 0.2f;
		} 
		else if (noiseTimer < noiseFlickTime * 2.0f ) 
		{
			noiseEffect.intensityMultiplier = ( noiseFlickTime - ( noiseTimer - noiseFlickTime ) ) * 4.0f;
			vignetteEffect.intensity = ( noiseFlickTime - ( noiseTimer - noiseFlickTime ) ) * 0.2f;
		} 
		else 
		{
			noiseTimer = 0.0f;
		}

		if (blurTimer < 4.0f) 
		{
			blurTimer += 0.4f;
			blurEffect.iterations = (int)(blurTimer * 1.0f);
		}
	}

	private void EnableVisualEffect(){
		if (blurEffect != null) {
			blurEffect.enabled = true;
		}
		if (noiseEffect != null) {
			noiseEffect.enabled = true;
		}
		if (vignetteEffect != null) {
			vignetteEffect.enabled = true;
		}
		if (bloodPartical != null) {
			bloodPartical.SetActive (true);
		}

		if ( audio != null  && !audio.isPlaying) {
			audio.Play ();
		}
	}

	private void DisableVisualEffect(){
		if (blurEffect != null) {
			blurEffect.enabled = false;
		}
		if (noiseEffect != null) {
			noiseEffect.enabled = false;
		}
		if (vignetteEffect != null) {
			vignetteEffect.enabled = false;
		}
		if (bloodPartical != null) {
			bloodPartical.SetActive (false);
		}
		if( audio != null ) audio.Stop ();
	}
}
