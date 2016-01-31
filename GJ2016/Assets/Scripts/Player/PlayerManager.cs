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

		GameObject sacrificePanel = Resources.Load<GameObject> ("Prefabs/SacrificePanel");
		GameObject sp =  GameObject.Instantiate (sacrificePanel);
		sp.transform.SetParent (p.Canvas);
		sp.transform.localScale = Vector3.one;
		sp.transform.localRotation = Quaternion.identity;
		p.panel = sp.GetComponent<SacrificePanel> ();
		p.panel.Index = index;

		GameObject hpPanel = Resources.Load<GameObject> ("Prefabs/HPPanel");
		GameObject hpp =  GameObject.Instantiate (hpPanel);
		hpp.transform.SetParent (p.Canvas);
		hpp.transform.localScale = Vector3.one;
		hpp.transform.localRotation = Quaternion.identity;
		p.hpPanel = hpp.GetComponent<HPPanel> ();

		GameObject sacrificeVisualEffectHandler = Resources.Load<GameObject> ("Prefabs/SacrificeVisualEffectHandler");
		GameObject se =  GameObject.Instantiate (sacrificeVisualEffectHandler);
		se.transform.SetParent (p.gameObject.transform);
		se.transform.localScale = Vector3.one;
		se.transform.localPosition = Vector3.zero;
		se.transform.localRotation = Quaternion.identity;

		SacrificeVisualEffectHandler sveHandler = se.GetComponent<SacrificeVisualEffectHandler>();
		sveHandler.eyesLostVisualEffect.camera = p.camera;
		sveHandler.handsLostVisualEffectHandler.camera = p.camera;
		sveHandler.legsLostVisualEffect.camera = p.camera;
		p.SVEHandler = sveHandler;
		return p;
	}

	public Score GetScore(int index)
	{
		return players [index].Score;
	}

	public void CutLeg(int index)
	{
		Player player = players[index];
		player.CutLeg ();

		Player enemy = players[1 - index];
		enemy.CloseLegs ();
		CurseOthers (index);
	}

	public void CutEye(int index)
	{
		Player player = players[index];
		player.CutEye ();

		Player enemy = players[1 - index];
		enemy.CloseEye ();
		CurseOthers (index);
	}

	public void CutHand(int index)
	{
		Player player = players[index];
		player.CutHand ();

		Player enemy = players[1 - index];
		enemy.CloseHands ();
		CurseOthers (index);
	}

	public void SendOrgan(int index)
	{
		Player player = players [index];
		player.SendOrgan ();
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

	public void EnterAlter(int index, bool isTrue)
	{
		players [index].EnterAlter (isTrue);
	}
}
