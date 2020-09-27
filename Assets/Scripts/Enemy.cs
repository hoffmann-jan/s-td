using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] Waypoints;
    public float Speed = 1.0f;

    private int currentWayPoint;
    private float lastWaypointSitchTime;

    // Start is called before the first frame update
    void Start()
    {
        currentWayPoint = 0;
        lastWaypointSitchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = Waypoints[currentWayPoint].transform.position;
        Vector3 nextPosition = Waypoints[currentWayPoint + 1].transform.position;

        float pathlength = Vector3.Distance(startPosition, nextPosition);
        float totalTimeForPathPart = pathlength / Speed;
        float currentTimeOnPathPart = Time.time - lastWaypointSitchTime;

        gameObject.transform.position = Vector2.Lerp(startPosition, nextPosition, currentTimeOnPathPart/totalTimeForPathPart);

        if (gameObject.transform.position.Equals(nextPosition))
        {
            if (currentWayPoint < Waypoints.Length - 2)
            {
                currentWayPoint++;
                lastWaypointSitchTime = Time.time;
                RotateEnemy(startPosition, nextPosition);
            }
            else
            {
                Destroy(gameObject);
                var health = GameManager.Instance.GetHealth();
                GameManager.Instance.SetHealth(health - 1);
            }

        }
    }

    private void RotateEnemy(Vector3 startPosition, Vector3 nextPosition)
    {
        Vector3 newDirection = nextPosition - startPosition;

        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;

        transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

}
