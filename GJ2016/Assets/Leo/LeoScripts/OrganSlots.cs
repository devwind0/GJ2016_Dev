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

    public int GetCorrectCount()
    {
        int correctCount = 0;
        for (int i = 0; i < _organs.Length && i < _correctResult.Length; ++i)
        {
            if (_organs[i]._organType == _correctResult[i])
            {
                correctCount++;
            }
        }
        return correctCount;
    }

}
