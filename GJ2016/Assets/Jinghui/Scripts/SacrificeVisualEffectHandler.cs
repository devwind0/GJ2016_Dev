using UnityEngine;
using System.Collections;

public class SacrificeVisualEffectHandler : MonoBehaviour {

	public EyesLostVisualEffect eyesLostVisualEffect;
	public LegsLostVisualEffectHandler legsLostVisualEffect;
	public HandsLostVisualEffectHandler handsLostVisualEffectHandler;

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

	public void EnableLegsVisualEffect(){
		legsLostVisualEffect.LegsLostVisualEffectFlag = true;
	}

	public void EnableHandsVisualEffect(){
		handsLostVisualEffectHandler.HandsLostVisualEffectFlag = true;
	}
}
