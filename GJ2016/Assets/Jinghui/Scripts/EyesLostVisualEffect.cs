using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class EyesLostVisualEffect : MonoBehaviour {

	public Blur blurEffect;
	public NoiseAndGrain noiseEffect;
	public VignetteAndChromaticAberration vignetteEffect;

	public float blurFlickTime = 4.0f;
	public float noiseFlickTime = 2.0f;

	private float noiseTimer = 0.0f;
	private float blurTimer = 0.0f;

	void Start () {

	}

	void Update () {
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
}
