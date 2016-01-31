using UnityEngine;
using System.Collections;

public enum OrganType
{
    Kidney,
    Heart,
    Lung,
    Brain,
    Unkonw,
}

public class OrganSlots : MonoBehaviour {
    [SerializeField]
    Organ[] _organs;

    public  PlayerEnum _player = PlayerEnum.PlayerA;
    public Organ _currentSelectedOrgan = null;
    public OrganType[] _correctResult;
	public Transform spawnPosition;

	private bool tokenSpawned = false;

    public void SwitchOrgan(Organ organA, Organ organB)
    {
        int indexOfA = GetIndexOfOrgan(organA);
        int indexOfB = GetIndexOfOrgan(organB);

        Vector3 temp = _organs[indexOfA].transform.localPosition;
        _organs[indexOfA].transform.localPosition = _organs[indexOfB].transform.localPosition;
        _organs[indexOfB].transform.localPosition = temp;

        Organ tempOrgin = _organs[indexOfA];
        _organs[indexOfA] = _organs[indexOfB];
        _organs[indexOfB] = tempOrgin;
    }

    public int GetIndexOfOrgan(Organ organ)
    {
        int index = -1;
        for (int i = 0; i < _organs.Length; ++i)
        {
            if (_organs[i] == organ)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public int GetCorrectCount(PlayerEnum player)
    {
        if (_player != player)
        {
            return -1;
        }
        int correctCount = 0;
        for (int i = 0; i < _organs.Length && i < _correctResult.Length; ++i)
        {
            if (_organs[i]._organType == _correctResult[i])
            {
                correctCount++;
            }
        }

		if (correctCount == 4) 
		{
			SpawnToken ((int)player);
		}
        return correctCount;
    }

	private void SpawnToken(int playerIndex)
	{
		if (!tokenSpawned) 
		{
			tokenSpawned = true;
			Score score = PlayerManager.Singleton.GetScore (playerIndex);
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
		GameObject prefab = Resources.Load<GameObject> (path);
		GameObject.Instantiate(prefab, spawnPosition.position, spawnPosition.rotation);
	}
}
