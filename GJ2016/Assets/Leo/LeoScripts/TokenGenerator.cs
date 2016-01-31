using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider))]
public class TokenGenerator : MonoBehaviour {

    BoxCollider _tokenTrigger = null;
    public PlayerEnum _player = PlayerEnum.PlayerA;
    public Transform _tokenGenPos = null;
	private bool tokenSpawned = false;
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
		SpawnToken (tokenIndex);
    }

	private void SpawnToken(int tokenIndex)
	{
		if (!tokenSpawned) 
		{
			tokenSpawned = true;
			Score score = PlayerManager.Singleton.GetScore (tokenIndex);
			int index = score.GetIndexOfWhatsLeft ();
			switch (index) 
			{
			case 0:
				SpawnObject ("Prefabs/hand");
				break;
			case 1:
				SpawnObject ("Prefabs/leg");
				break;
			case 2:
				SpawnObject ("Prefabs/eyeball");
				break;
			}
		}
	}

	private void SpawnObject(string path)
	{
		Debug.LogError ("Spawn " + path);
		GameObject prefab = Resources.Load<GameObject> (path);
		GameObject.Instantiate(prefab, _tokenGenPos.position, _tokenGenPos.rotation);
	}
}
