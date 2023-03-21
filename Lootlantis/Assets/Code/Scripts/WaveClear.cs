using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveClear : MonoBehaviour
{

    public Text text;

    public void Clear() {
        Time.timeScale = 0;
        text.text = "Wave Clear\nCurrent Gold: " + PlayerPrefs.GetInt("Currency") + "\n\nYou will keep all earned gold\nif you go to main menu";
        gameObject.SetActive(true);

    }   

    public void NewWave(){
        if (PlayerPrefs.GetInt("Wave") == 1)
        {
            PlayerPrefs.SetInt("Wave", 2);
            SceneManager.LoadScene(5);
        } else if (PlayerPrefs.GetInt("Wave") == 2)
        {
            PlayerPrefs.SetInt("Wave", 3);
            SceneManager.LoadScene(6);
        }else if (PlayerPrefs.GetInt("Wave") == 3)
        {
            PlayerPrefs.SetInt("Wave", 4);
            SceneManager.LoadScene(7);
        }else if (PlayerPrefs.GetInt("Wave") == 4)
        {
            PlayerPrefs.SetInt("Wave", 5);
            SceneManager.LoadScene(8);
        } else
        {
            PlayerPrefs.SetInt("Wave", 6);
            SceneManager.LoadScene(9);
        }

        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);

        Time.timeScale = 1;
    }
}
