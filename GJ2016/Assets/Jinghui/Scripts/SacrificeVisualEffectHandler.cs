using UnityEngine;
using System.Collections;

public class SacrificeVisualEffectHandler : MonoBehaviour {

	public EyesLostVisualEffect eyesLostVisualEffect;

	void Start () {
	
	}

	void Update () {
	
	}

	public void EnableEyesLostVisualEffect( int index ){
		eyesLostVisualEffect.EyesLostVisualEffectFlag = true;
		eyesLostVisualEffect.SetBloodEffectLayer(index);
	}

	public void DisableEyesLostVisualEffect( ){
		
	}

	public void CloseEyesLostVisualEffect( int index ){
		eyesLostVisualEffect.SetCameraCullingMask(index);
	}
}
