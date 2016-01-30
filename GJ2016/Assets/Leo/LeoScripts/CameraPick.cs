using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraPick : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        /*
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Organ"))
            {
                Debug.Log("Orgn" + hit.collider.name);
            }
        }
        */
    }

    void OnTriggerEnter(Collider i_other)
    {
        Organ organ = i_other.GetComponent<Organ>();
        OrganSlot slot = i_other.GetComponent<OrganSlot>();
        if (organ == null && slot == null)
            return;
        organ.OnSelectStart();
    }


    void OnTriggerExit(Collider i_other)
    {
        Organ organ = i_other.GetComponent<Organ>();
        OrganSlot slot = i_other.GetComponent<OrganSlot>();
        if (organ == null && slot == null)
            return;
        organ.OnSelectEnd();

    }

}
