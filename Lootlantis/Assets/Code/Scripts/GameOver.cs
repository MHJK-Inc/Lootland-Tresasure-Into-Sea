using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource but;
    public AudioClip buttonClick;
    
    public void gameOver() {
        Time.timeScale = 0;
        gameObject.SetActive(true);

    }   

    public void restart(){
        but.PlayOneShot(buttonClick);
        Time.timeScale = 1;
        SceneManager.LoadScene(2);

        
    }

    public void mainMenu()
    {
        but.PlayOneShot(buttonClick);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

        
    }
}
