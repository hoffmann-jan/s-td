using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject TowerPrefab;

    private GameObject tower;

    private void OnMouseUp()
    {
        if (tower == null)
        {
            tower = Instantiate<GameObject>(TowerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            if (CanUpgrade())
            {
                TowerData data = tower.GetComponent<TowerData>();
                data.IncreaseLevel();
            }
        }
    }

    private bool CanUpgrade()
    {
        if (tower == null)
        {
            return false;
        }

        TowerData data = tower.GetComponent<TowerData>();

        TowerLevel next = data.GetNextLevel();

        if (next == null)
        {
            return false;
        }

        return true;
    }
}
