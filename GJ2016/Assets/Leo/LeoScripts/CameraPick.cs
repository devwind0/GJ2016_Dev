using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraPick : MonoBehaviour {


    void Start()
    {

    }


    void OnTriggerEnter(Collider i_other)
    {
        Organ organ = i_other.GetComponent<Organ>();
        if (organ == null)
            return;
        organ.OnHighLightStart();
    }


    void OnTriggerExit(Collider i_other)
    {
        Organ organ = i_other.GetComponent<Organ>();
        if (organ == null)
            return;
        organ.OnHihgLightEnd();

    }

}
