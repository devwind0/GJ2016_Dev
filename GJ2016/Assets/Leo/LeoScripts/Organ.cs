using UnityEngine;
using System.Collections.Generic;



[RequireComponent(typeof(BoxCollider))]
public class Organ : MonoBehaviour {

    public Material _hightLitMaterial;
    MeshRenderer[] _renders = null;
    List<Material> _defaultMats = new List<Material>();

    public OrganType _organType = OrganType.Unkonw;

    public bool OnSelected
    {
        get { return _onSelected; }
    }
    bool _onSelected = false;


	// Use this for initialization
	void Start ()
    {
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
	
	// Update is called once per frame
	void OnSelectStart()
    {
        if (_renders == null)
            return;

        foreach (MeshRenderer mr in _renders)
        {
            for (int i = 0; i < mr.materials.Length; ++i)
            {
                mr.materials[i] = _hightLitMaterial;
               // mr.materials[i].color = Color.red;
            }
        }
        _onSelected = true;
    }

    void OnSelectEnd()
    {
        if (_renders == null)
            return;
        int index = 0;
        foreach (MeshRenderer mr in _renders)
        {
            for (int i = 0; i < mr.materials.Length; ++i)
            {
                mr.materials[i] = _defaultMats[index++];
             //   mr.materials[i].color = Color.grey;
            }
        }
        _onSelected = false;
    }

    void OnTriggerEnter(Collider i_other)
    {
        Debug.Log("Entered");
        OnSelectStart();
    }

    void OnTriggerExit(Collider i_other)
    {
        Debug.Log("Exited");
        OnSelectEnd();
    }
}
