using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{

    public GameObject player;

    public void pause() {
        Time.timeScale = 0;
        gameObject.SetActive(true);

    }   

    public void unpause(){
        gameObject.SetActive(false);
        Time.timeScale = 1;   
        player.GetComponent<Player>().paused = false;     
    }

    public void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

        
    }
}
