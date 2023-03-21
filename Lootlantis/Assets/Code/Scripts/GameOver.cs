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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(1);

        Time.timeScale = 1;
    }
}
