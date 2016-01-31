using UnityEngine;
using System.Collections;

public enum PlayerEnum
{
    PlayerA,
    PlayerB,
}

[RequireComponent(typeof(Camera))]
public class PlayerCam : MonoBehaviour {

    public PlayerEnum _player = PlayerEnum.PlayerA;
    Camera _cam = null;

    // Use this for initialization
    void Start () {
        _cam = GetComponent<Camera>();
        switch (_player)
        {
            case PlayerEnum.PlayerA:
                _cam.rect = new Rect(0f, 0f, 0.5f, 1f);
                break;
            case PlayerEnum.PlayerB:
                _cam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                break; 
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
