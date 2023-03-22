using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void gameOver() {
        Time.timeScale = 0;
        gameObject.SetActive(true);

    }   

    public void restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
    }

    public void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

        
    }
}
