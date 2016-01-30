using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class EyesLostVisualEffect : MonoBehaviour {

	public Camera camera;

	public GameObject bloodPartical;
	public AudioSource audio;

	public bool EyesLostVisualEffectFlag{
		get{ return m_visualEffectFlag; }
		set{ 
			m_visualEffectFlag = value; 
			if (value) {
				EnableVisualEffect ();
			} 
			else {
				DisableVisualEffect ();
			}

		}
	}

	public float blurFlickTime = 4.0f;
	public float noiseFlickTime = 2.0f;

	private Blur blurEffect;
	private NoiseAndGrain noiseEffect;
	private VignetteAndChromaticAberration vignetteEffect;

	private float noiseTimer = 0.0f;
	private float blurTimer = 0.0f;

	private bool m_visualEffectFlag = false;

	void Start () {
			if (camera != null) {
				blurEffect = camera.gameObject.GetComponent<Blur> ();
				noiseEffect = camera.gameObject.GetComponent<NoiseAndGrain> ();
				vignetteEffect = camera.gameObject.GetComponent<VignetteAndChromaticAberration> ();
			}

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

		blurTimer += Time.deltaTime;
		if (blurTimer < blurFlickTime) {
			blurEffect.iterations = (int)(blurTimer * 1.0f);
		} else if (blurTimer > 3.0f * blurFlickTime && blurTimer < 4.0f * blurFlickTime) {
			blurEffect.iterations = (int)((blurFlickTime - (blurTimer - blurFlickTime)) * 1.0f);
		} else if (blurTimer > 4.0f * blurFlickTime && blurTimer < 7.0f * blurFlickTime) {
			blurEffect.enabled = false;
		}
		else if( blurTimer > 7.0f * blurFlickTime){
			blurEffect.enabled = true;
			blurTimer = 0.0f;
		}
	}

	public void SetBloodEffectLayer( int index ){
		bloodPartical.layer = index + 8;
	}

	public void SetCameraCullingMask(int index ){
		int bloodLayer = ( 1 - index ) + 8;
		camera.cullingMask = ~(1 << bloodLayer);
	}

	public void EnableVisualEffect(){
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

	public void DisableVisualEffect(){
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