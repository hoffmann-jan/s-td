using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    public List<TowerLevel> TowerLevel;
    public TowerLevel CurrentLevel;

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
}
