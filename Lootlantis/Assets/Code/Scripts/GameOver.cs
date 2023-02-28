using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void gameOver() {
        gameObject.SetActive(true);

    }   

    public void restart(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
