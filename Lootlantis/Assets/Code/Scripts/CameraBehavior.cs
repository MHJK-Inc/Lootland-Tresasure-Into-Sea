using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Speed that it follows
    public float FollowSpeed = 2f;

    public float yOffset = 1f;

    public GameOver GameOverScreen;

    // Target that it follows
    public Transform target;

    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale != 0f)
        {
            // Tracks location of target (Set to player game object) and follows it on update
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        }
    }

    public void GameOver(){
        GameOverScreen.gameOver();
    }
}
