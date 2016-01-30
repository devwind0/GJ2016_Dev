using UnityEngine;
using System.Collections;

public enum OrganType
{
    Kidney,
    Heart,
    Lung,
    Brain,
    Unkonw,
}

public class OrganSlots : MonoBehaviour {
    [SerializeField]
    Organ[] _organs;

    [SerializeField]
    GameObject[] _slots;

    public Organ _currentSelectedOrgan = null;
    

    // Update is called once per frame
    void Update () {
        if (_organs == null)
            return;
        if (Input.GetButtonDown("Fire1")) {
            OrganType selectedType = OrganType.Unkonw;
            int i = 0;
            for ( ; i< _organs.Length; ++i)
            {
                if (_organs[i].OnSelected)
                {
                    _currentSelectedOrgan = _organs[i];
                    selectedType = _organs[i]._organType;
                    break;
                }
            }
            if (selectedType != OrganType.Unkonw)
                ChangeOrder(i);
            else
                _currentSelectedOrgan = null;
        }
	}

    void ChangeOrder(int indexOfOrgan)
    {
        Debug.Log("OnFire:" + indexOfOrgan);
        int nextOrganIndex = (indexOfOrgan + 1) % _organs.Length;
        Vector3 temp = _organs[indexOfOrgan].transform.localPosition;
        _organs[indexOfOrgan].transform.localPosition = _organs[nextOrganIndex].transform.localPosition;
        _organs[nextOrganIndex].transform.localPosition = temp;

        Organ tempOrgin = _organs[indexOfOrgan];
        _organs[indexOfOrgan] = _organs[nextOrganIndex];
        _organs[nextOrganIndex] = tempOrgin;

    }

    void UpdateCurrentOrganPosition()
    {

    }

}
