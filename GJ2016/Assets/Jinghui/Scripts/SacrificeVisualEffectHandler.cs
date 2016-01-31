using UnityEngine;
using System.Collections;

public class SacrificeVisualEffectHandler : MonoBehaviour {

	public EyesLostVisualEffect eyesLostVisualEffect;
	public LegsLostVisualEffectHandler legsLostVisualEffect;
	public HandLostVisualEffectHandler handsLostVisualEffectHandler;

	void Start () {
	
	}

	void Update () {
	
	}

	public void EnableEyesLostVisualEffect( int index ){
		eyesLostVisualEffect.EyesLostVisualEffectFlag = true;
		eyesLostVisualEffect.SetBloodEffectLayer(index);
	}
		
	public void EnableLegsVisualEffect(int index ){
		legsLostVisualEffect.LegsLostVisualEffectFlag = true;
		legsLostVisualEffect.SetBloodEffectLayer(index);
	}

	public void EnableHandsVisualEffect(int index){
		handsLostVisualEffectHandler.HandsLostVisualEffectFlag = true;
		handsLostVisualEffectHandler.SetBloodEffectLayer(index);
	}

	public void CloseEyesLostVisualEffect( int index ){
		eyesLostVisualEffect.SetCameraCullingMask(index);
	}

	public void CloseLegsLostVisualEffect( int index ){
		legsLostVisualEffect.SetCameraCullingMask(index);
	}

	public void CloseHandsLostVisualEffect( int index ){
		handsLostVisualEffectHandler.SetCameraCullingMask(index);
	}
}
