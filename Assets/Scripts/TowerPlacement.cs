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
    }
}
