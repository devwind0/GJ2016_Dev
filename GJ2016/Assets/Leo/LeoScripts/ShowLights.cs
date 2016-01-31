using UnityEngine;
using System.Collections;

public class ShowLights : MonoBehaviour {

    OrganSlots _organSlots = null;

	// Use this for initialization
	void Start () {
        _organSlots = GetComponentInParent<OrganSlots>();
    }
	
	// Update is called once per frame
	void Update () {
        if (_organSlots == null)
            return;
        int correctCount = _organSlots.GetCorrectCount(_organSlots._player);
        MeshRenderer[] meshRenders = GetComponentsInChildren<MeshRenderer>();
        for(int i = 0; i < meshRenders.Length; ++i)
        {
            if (i < correctCount)
            {
                meshRenders[i].material.color = Color.green;
            }
            else
            {
                meshRenders[i].material.color = Color.white;
            }
        }
    }
}
