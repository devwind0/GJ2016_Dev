using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager 
{
    public static PlayerManager Singleton 
    {
        get
        {
            if(instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }

    private static PlayerManager instance;

	private Player[] players = new Player[GameConstants.PlayerCount];

	public PlayerManager()
	{
		
	}

	public void Init(Transform[] playerSpots)
	{
		//TODO Add each player to each camera
		for(int i = 0; i < GameConstants.PlayerCount; ++i)
		{
			players [i] = CreatePlayer (i);
			players [i].transform.position = playerSpots [i].position;
			players [i].transform.rotation = playerSpots [i].rotation;
		}

		CreateTerrain ();
	}

	private void CreateTerrain()
	{
		GameObject terrainPrefab =  Resources.Load<GameObject> ("Prefabs/Terrain");
		GameObject.Instantiate (terrainPrefab, Vector3.zero, Quaternion.identity);
	}

	public Player CreatePlayer(int index)
	{
		GameObject playerPrefab =  Resources.Load<GameObject> ("Prefabs/Player"+index.ToString());
		GameObject player =  GameObject.Instantiate (playerPrefab);
		if (player == null) 
		{
			Debug.LogError ("Player Null");
		}

		Player p = player.GetComponent<Player> ();
		p.Index = index;
		p.panel.Index = index;
		return p;
	}

	public void CutLeg(int index)
	{
		Player player = players[index];
		player.CutLeg ();
		CurseOthers (index);
	}

	public void CutEye(int index)
	{
		Player player = players[index];
		player.CutEye ();
		CurseOthers (index);
	}

	public void CutHand(int index)
	{
		Player player = players[index];
		player.CutHand ();
		CurseOthers (index);
	}

	public void CurseOthers(int playerIndex)
	{
		//make all the other guys cursed
		for (int i = 0; i < GameConstants.PlayerCount; ++i) 
		{
			if (i == playerIndex)
				continue;
			Player other = players [i];
			other.Cursed ();
		}
	}
}
