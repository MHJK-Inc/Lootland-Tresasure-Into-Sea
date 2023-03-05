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
    public GameObject player; // Reference to the player object.

    float countUp = 0;

    void Start()
    {
        CreateBodyParts();
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
        //Using the player as reference, gets the distance and direction of the player
        Vector3 direction = player.transform.position - serpentBody[0].transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        serpentBody[0].GetComponent<Rigidbody2D>().rotation = angle;

        if (direction.x < 0)
        {
            serpentBody[0].GetComponent<SpriteRenderer>().flipX = true;
            Debug.Log("Flipping sprite to face left");
        }
        else
        {
            serpentBody[0].GetComponent<SpriteRenderer>().flipX = false;
            Debug.Log("Flipping sprite to face right");
        }

        direction.Normalize();
        serpentBody[0].GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;

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
}
