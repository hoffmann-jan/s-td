using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    public List<TowerLevel> TowerLevel;
    public TowerLevel CurrentLevel;

    private void OnEnable()
    {
        CurrentLevel = TowerLevel[0];
        SetTowerLevel(CurrentLevel);
    }

    public void SetTowerLevel(TowerLevel towerLevel)
    {
        CurrentLevel = towerLevel;

        int currentIndex = TowerLevel.IndexOf(CurrentLevel);
        GameObject tower = TowerLevel[currentIndex].Tower;

        for (int i = 0; i < TowerLevel.Count; i++)
        {
            if (tower != null)
            {
                if (i == currentIndex)
                {
                    TowerLevel[i].Tower.SetActive(true);
                }
                else
                {
                    TowerLevel[i].Tower.SetActive(false);
                }
            }
        }
    }

    public TowerLevel GetNextLevel()
    {
        int currentIndex = TowerLevel.IndexOf(CurrentLevel);
        int maximumIndex = TowerLevel.Count - 1;

        if (currentIndex - maximumIndex == 0)
        {
            return null;
        }
        else
        {
            return TowerLevel[currentIndex + 1];
        }
    }

    public void IncreaseLevel()
    {
        int currentIndex = TowerLevel.IndexOf(CurrentLevel);
        if (currentIndex < TowerLevel.Count - 1)
        {
            CurrentLevel = TowerLevel[currentIndex + 1];
            SetTowerLevel(CurrentLevel);
        }
    }
}
