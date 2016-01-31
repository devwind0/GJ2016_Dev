using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider))]
public class TokenGenerator : MonoBehaviour {

    BoxCollider _tokenTrigger = null;
    public PlayerEnum _player = PlayerEnum.PlayerA;
    public GameObject _tokenPrefab = null;
    public Transform _tokenGenPos = null;
    // Use this for initialization
    void Start () {
        _tokenTrigger = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter (Collider i_other) {
        CharacterController cc = i_other.GetComponent<CharacterController>();
        if (cc == null)
            return;
        if (_tokenTrigger == null)
            return;
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
        int tokenIndex = playerScore.GetIndexOfWhatsLeft();
        Instantiate(_tokenPrefab, _tokenGenPos.position, Quaternion.identity);
    }
}
