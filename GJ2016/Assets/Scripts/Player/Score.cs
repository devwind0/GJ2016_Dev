using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum OrganState
{
	None,
	Carry,
	Sent
}

public class Score 
{
    public OrganState[] GetOrganStats()
    {
        return organs;
    }

    private OrganState[] organs = new OrganState[3];  
	private bool[] cutState = new bool[3];

	public void CutOrgan(int index)
	{
		cutState [index] = true;
	}

	public void CarryOrgan(int index)
	{
		organs [index] = OrganState.Carry;
	}

	public void SendOrgan()
	{
		for(int i = 0; i < 3; ++i)
		{
			if (organs [i] == OrganState.Carry)
				organs [i] = OrganState.Sent;
		}
	}

	public bool HasAll()
	{
		for (int i = 0; i < 3; ++i) 
		{
			if (organs [i] == OrganState.Carry || organs [i] == OrganState.None)
				return false;
		}

		return true;
	}

	public int GetIndexOfWhatsLeft()
	{
		List<int> indices = new List<int> ();
		for (int i = 0; i < 3; ++i) 
		{
			if (organs [i] == OrganState.Sent) 
			{
				indices.Add (i);
			}
		}

		int count = indices.Count;
		return Random.Range (0, count);
	}
}
