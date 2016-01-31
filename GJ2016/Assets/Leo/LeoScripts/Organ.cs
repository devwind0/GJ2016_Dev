using UnityEngine;
using System.Collections.Generic;


public class Organ : MonoBehaviour {

    public Material _hightLitMaterial;
    MeshRenderer[] _renders = null; 
    List<Material> _defaultMats = new List<Material>();

    public OrganType _organType = OrganType.Unkonw;

    bool _onHighLight = false;

    OrganSlots _slots;

    // Use this for initialization
    void Start ()
    {
        _slots = GetComponentInParent<OrganSlots>();
        _renders = GetComponentsInChildren<MeshRenderer>();
        if (_renders == null)
            return;
        foreach (MeshRenderer mr in _renders)
        {
            foreach (Material mat in mr.materials)
            {
                _defaultMats.Add(mat);
            }
        }
    }

    void Update()
    {
        if (_slots == null)
            return;
        // Make sure that we got input from playerA or,
        // we get the input from playerB.
        bool playerAInput = Input.GetButtonDown("Fire2") ;
        bool playerBInput = Input.GetButtonDown("Fire1");
        if (_slots._player == PlayerEnum.PlayerA && !playerAInput) 
        {
            return;
        }
        if (_slots._player == PlayerEnum.PlayerB && !playerBInput)
        {
            return;
        }

        if (playerAInput || playerBInput)
        {
            if (_onHighLight)
            {
                if (_slots._currentSelectedOrgan == null)
                {
                    _slots._currentSelectedOrgan = this;
                    Vector3 pos = transform.position;
                    pos.y += 0.5f;
                    transform.position = pos;
                }
                else
                {
                    _slots.SwitchOrgan(_slots._currentSelectedOrgan, this);
                    _slots._currentSelectedOrgan = null;
                    Vector3 pos = transform.position;
                    pos.y -= 0.5f;
                    transform.position = pos;
                }
            }
        }
    }

	// Update is called once per frame
	public void OnHighLightStart()
    {
        if (_renders == null)
            return;

        foreach (MeshRenderer mr in _renders)
        {
            for (int i = 0; i < mr.materials.Length; ++i)
            {
                mr.materials[i] = _hightLitMaterial;
                mr.materials[i].color = Color.red;
            }
        }
        _onHighLight = true;
    }

    public void OnHihgLightEnd()
    {
        if (_renders == null)
            return;
        int index = 0;
        foreach (MeshRenderer mr in _renders)
        {
            for (int i = 0; i < mr.materials.Length; ++i)
            {
                mr.materials[i] = _defaultMats[index++];
                mr.materials[i].color = Color.grey;
            }
        }
        _onHighLight = false;
    }

}
