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

    private int wayPointIndex = 0;
    private Vector3 headPosition;
    private SpawnSerpent spawnSerpent;
    public GameObject coin;

    float countUp = 0;

    void Start()
    {
        CreateBodyParts();
        headPosition = serpentBody[0].transform.position;      
        for (int i = 0; i < 6; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle.normalized * waypointRadius;
            Vector3 waypointPosition = headPosition + new Vector3(randomPoint.x, randomPoint.y, 0f);
            GameObject waypointObject = new GameObject("Waypoint " + i);
            waypointObject.transform.position = waypointPosition;
            wayPoints.Add(waypointObject.transform);
        }
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
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = new Vector3(wayPoints[wayPointIndex].position.x, wayPoints[wayPointIndex].position.y, wayPoints[wayPointIndex].position.z);
            Vector2 direction = Vector3.Normalize(targetPosition - headPosition);
            headPosition += (Vector3)direction * moveSpeed * Time.deltaTime;

            if (Vector2.Distance(headPosition, targetPosition) < 0.1f)
            {
                wayPointIndex = (wayPointIndex + 1) % wayPoints.Count;
            }
        }

        serpentBody[0].transform.position = headPosition;


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
        Debug.Log(isDead);
        if (isDead)
        {
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
        //float dropChance = 0.5f; 
        //if (Random.value <= dropChance)
        //{
        // Spawn the item at the enemy's position
        GameObject item = Instantiate(coin, serpentBody[0].transform.position, Quaternion.identity);
        
        //}
    }
}