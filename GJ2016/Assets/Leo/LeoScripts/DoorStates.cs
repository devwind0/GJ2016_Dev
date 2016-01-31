using UnityEngine;
using System.Collections;

public class DoorStates : MonoBehaviour {

    Transform _door1 = null;
    Transform _door2 = null;
    public PlayerEnum _player = PlayerEnum.PlayerA;
    public int _organSentCount = 0;

    // Use this for initialization
    void Start () {
        _door1 = transform.FindChild("Door (1)");
        _door2 = transform.FindChild("Door (2)");
    }
	
	// Update is called once per frame
	void Update () {
        int playerIndex = 0;
        switch (_player)
        {
            case PlayerEnum.PlayerA:
                playerIndex = 0;
                break;
            case PlayerEnum.PlayerB:
                playerIndex = 1;
                break;
        }
        Score playerScore = PlayerManager.Singleton.GetScore(playerIndex);
        OrganState[] organStats = (playerScore.GetOrganStats());
        foreach (OrganState os in organStats)
        {
            if (os == OrganState.Sent)
            {
                ++_organSentCount;
            }
        }
        if (_organSentCount > 0)
        {
            _door2.gameObject.SetActive(false);
        }
        if (_organSentCount > 1)
        {
            _door1.gameObject.SetActive(false);
        }
    }
}
