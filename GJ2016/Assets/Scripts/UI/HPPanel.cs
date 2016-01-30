using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPPanel : MonoBehaviour {

	public Text HPText;
	public RectTransform HPProgress;

	private static float HP_CAP = 100.0f;

	public void SetHP(float HPAmount)
	{
		HPProgress.anchorMax = new Vector2 (HPAmount / HP_CAP, 1.0f);
		HPText.text = ((int)HPAmount).ToString ();
	}
}
