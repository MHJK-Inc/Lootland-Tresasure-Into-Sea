using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serpent : MonoBehaviour
{
    [SerializeField] float distanceBetween = .2f;
    [SerializeField] float speed = 280;
    [SerializeField] float turnSpeed = 18;
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> serpentBody = new List<GameObject>();
    [SerializeField] private List<Transform> wayPoints = new List<Transform>();
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] float waypointRadius = 2f;


    public GameObject player;
    private float distance;
    public float distanceFromPlayer = 25f;
    public float minDistance = 0.2f;
    public float maxDistance = 0.5f;

    private float minD;
    private float maxD;

    private int wayPointIndex = 0;
    private Vector3 headPosition;
    private SpawnSerpent spawnSerpent;
    public GameObject coin;
    public GameObject bubble;

    private float posX;
    private float posY;

    float countUp = 0;

    void Start()
    {
        CreateBodyParts();
        headPosition = serpentBody[0].transform.position;
        // Create a new list of waypoints
        List<Transform> newWayPoints = new List<Transform>();
        // Add the current position as the first waypoint
        //newWayPoints.Add(new GameObject("Waypoint 0", typeof(Transform)).transform);
        //newWayPoints[0].position = headPosition;
        // Define the rectangular area
        float rectangleWidth = 2 * waypointRadius;
        float rectangleHeight = 4 * waypointRadius;
        Vector3 topLeft = new Vector3(headPosition.x - rectangleWidth / 2, headPosition.y + rectangleHeight / 2, 0f);
        Vector3 topRight = new Vector3(headPosition.x + rectangleWidth / 2, headPosition.y + rectangleHeight / 2, 0f);
        Vector3 bottomLeft = new Vector3(headPosition.x - rectangleWidth / 2, headPosition.y - rectangleHeight / 2, 0f);
        Vector3 bottomRight = new Vector3(headPosition.x + rectangleWidth / 2, headPosition.y - rectangleHeight / 2, 0f);

        // Create new waypoints in a rectangular pattern
        newWayPoints.Add(new GameObject("Waypoint 0", typeof(Transform)).transform);
        newWayPoints[0].position = topRight;

        newWayPoints.Add(new GameObject("Waypoint 1", typeof(Transform)).transform);
        newWayPoints[1].position = topLeft;

        newWayPoints.Add(new GameObject("Waypoint 2", typeof(Transform)).transform);
        newWayPoints[2].position = bottomLeft;

        newWayPoints.Add(new GameObject("Waypoint 3", typeof(Transform)).transform);
        newWayPoints[3].position = bottomRight;

        wayPoints = newWayPoints;
        wayPointIndex = 0;

        //On creation finds the "Player" gameobject
        player = GameObject.Find("Player");

        minD = distanceFromPlayer * minDistance;
        maxD = distanceFromPlayer * maxDistance;
        spawnSerpent = FindObjectOfType<SpawnSerpent>();

    }

    void FixedUpdate()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
        SerpentMovement();
    }

    void SerpentMovement()
    {

        float distance = Vector3.Distance(serpentBody[0].transform.position, player.transform.position);
        if (distance >= distanceFromPlayer)
        {
            MoveCloserToPlayer();
        }

        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = new Vector3(wayPoints[wayPointIndex].position.x, wayPoints[wayPointIndex].position.y, wayPoints[wayPointIndex].position.z);
            Vector2 direction = Vector3.Normalize(targetPosition - headPosition);
            headPosition += (Vector3)direction * moveSpeed * Time.deltaTime;

            if (Vector2.Distance(headPosition, targetPosition) < 0.1f)
            {
                wayPointIndex = (wayPointIndex + 1) % wayPoints.Count;
            }
            serpentBody[0].transform.position = headPosition;
            Debug.Log(wayPointIndex);
            switch (wayPointIndex)
            {
                case 0:
                    serpentBody[0].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    break;
                case 1:
                    serpentBody[0].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                    break;
                case 2:
                    serpentBody[0].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                    break;
                case 3:
                    serpentBody[0].transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                    break;
            }

        }



        if (serpentBody.Count > 1)
        {
            for (int i = 1; i < serpentBody.Count; i++)
            {
                SerpentManager markM = serpentBody[i - 1].GetComponent<SerpentManager>();
                serpentBody[i].transform.position = markM.markerList[0].position;
                serpentBody[i].transform.rotation = markM.markerList[0].rotation;
                markM.markerList.RemoveAt(0);
            }
        }
    }

    void MoveCloserToPlayer()
    {
        // Move the serpent to a new position near the player
        float distanceToMove = Random.Range(minD, maxD);
        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 newPosition = new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0) * distanceToMove;
        newPosition += player.transform.position;

        // Ensure the new position is not too close to any existing serpent
        foreach (GameObject serpent in spawnSerpent.enemyList)
        {
            if (Vector3.Distance(serpent.transform.position, newPosition) < 2 * waypointRadius)
            {
                Vector2 randomPoint = Random.insideUnitCircle.normalized * waypointRadius;
                newPosition = player.transform.position + new Vector3(randomPoint.x, randomPoint.y, 0f);
                break;
            }
        }

        // Ensure the new position is within the game boundaries (if necessary)
        // newPosition = ClampPosition(newPosition);
        headPosition = newPosition;

        // Create a new list of waypoints
        List<Transform> newWayPoints = new List<Transform>();
        // Add the current position as the first waypoint
        //newWayPoints.Add(new GameObject("Waypoint 0", typeof(Transform)).transform);
        //newWayPoints[0].position = newPosition;


        // Define the rectangular area
        float rectangleWidth = 2 * waypointRadius;
        float rectangleHeight = 4 * waypointRadius;
        Vector3 topLeft = new Vector3(newPosition.x - rectangleWidth / 2, newPosition.y + rectangleHeight / 2, 0f);
        Vector3 topRight = new Vector3(newPosition.x + rectangleWidth / 2, newPosition.y + rectangleHeight / 2, 0f);
        Vector3 bottomLeft = new Vector3(newPosition.x - rectangleWidth / 2, newPosition.y - rectangleHeight / 2, 0f);
        Vector3 bottomRight = new Vector3(newPosition.x + rectangleWidth / 2, newPosition.y - rectangleHeight / 2, 0f);

        // Create new waypoints in a rectangular pattern
        newWayPoints.Add(new GameObject("Waypoint 0", typeof(Transform)).transform);
        newWayPoints[0].position = topRight;

        newWayPoints.Add(new GameObject("Waypoint 1", typeof(Transform)).transform);
        newWayPoints[1].position = topLeft;

        newWayPoints.Add(new GameObject("Waypoint 2", typeof(Transform)).transform);
        newWayPoints[2].position = bottomLeft;

        newWayPoints.Add(new GameObject("Waypoint 3", typeof(Transform)).transform);
        newWayPoints[3].position = bottomRight;


        // Set the new waypoints and reset the waypoint index
        wayPoints = newWayPoints;
        wayPointIndex = 0;
    }


    void CreateBodyParts()
    {
        if (serpentBody.Count == 0)
        {
            GameObject temp1 = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);

            if (!temp1.GetComponent<SerpentManager>())
                temp1.AddComponent<SerpentManager>();
            if (!temp1.GetComponent<Rigidbody2D>())
                temp1.AddComponent<Rigidbody2D>();

            temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
            serpentBody.Add(temp1);
            bodyParts.RemoveAt(0);
        }

        SerpentManager markM = serpentBody[serpentBody.Count - 1].GetComponent<SerpentManager>();
        if (countUp == 0)
        {
            markM.ClearMarkerList();
        }
        countUp += Time.deltaTime;

        if (countUp >= distanceBetween)
        {
            GameObject temp = Instantiate(bodyParts[0], markM.markerList[0].position, markM.markerList[0].rotation, transform);

            if (!temp.GetComponent<SerpentManager>())
                temp.AddComponent<SerpentManager>();
            if (!temp.GetComponent<Rigidbody2D>())
            {
                temp.AddComponent<SerpentManager>();
                temp.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

            serpentBody.Add(temp);
            bodyParts.RemoveAt(0);
            temp.GetComponent<SerpentManager>().ClearMarkerList();
            countUp = 0;
        }
    }
    public void DestroySerpent(bool isDead)
    {
        if (isDead)
        {
            GameObject.Find("Main Camera").GetComponent<WaveControl>().EnemiesLeft--;
            spawnSerpent.EnemyDestroyed();
            Destroy(gameObject);
            DropItem();
            foreach (Transform wp in wayPoints)
            {
                Destroy(wp.gameObject);
            }
        }
    }
    public void DropItem()
    {
        float dropChance = 0.75f; 
        float value = Random.value;
        if (Random.value <= dropChance)
        {
            // Spawn the item at the enemy's position
            float whichDrop = 0.75f;
            value = Random.value;
            if(value <= whichDrop)
            {
              GameObject item = Instantiate(bubble, transform.position, Quaternion.identity);  
            } else
            {
                GameObject item = Instantiate(coin, transform.position, Quaternion.identity);
            }
            
        }
    }
}