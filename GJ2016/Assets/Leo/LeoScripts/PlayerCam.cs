using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class PlayerCam : MonoBehaviour {

    public enum Player
    {
        PlayerA,
        PlayerB,
    }
    public  Player _player = Player.PlayerA;
    Camera _cam = null;

    // Use this for initialization
    void Start () {
        _cam = GetComponent<Camera>();
        switch (_player)
        {
            case Player.PlayerA:
                _cam.rect = new Rect(0f, 0f, 0.5f, 1f);
                break;
            case Player.PlayerB:
                _cam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                break; 
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
