using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveClear : MonoBehaviour
{

    public TMPro.TextMeshProUGUI nextWaveTxt;

    public Text text;

    public AudioSource but;
    public AudioClip buttonClick;

    public void Clear() {
        if(PlayerPrefs.GetInt("Wave") < 6)
        {
            Time.timeScale = 0;
            text.text = "Wave Clear\nCurrent Gold: " + PlayerPrefs.GetInt("Currency") + "\n\nYou will keep all earned gold\nif you go to main menu";
            gameObject.SetActive(true);
        } else {
            Time.timeScale = 0;
            text.text = "Game Clear\nCurrent Gold: " + PlayerPrefs.GetInt("Currency") + "\n\nYou survived!";
            gameObject.SetActive(true);
            nextWaveTxt.text = "Continue";
        }

    }   

    

    public void NewWave(){
        but.PlayOneShot(buttonClick);
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Wave") == 1)
        {
            PlayerPrefs.SetInt("Wave", 2);
            SceneManager.LoadScene(4);
        } else if (PlayerPrefs.GetInt("Wave") == 2)
        {
            PlayerPrefs.SetInt("Wave", 3);
            SceneManager.LoadScene(5);
        }else if (PlayerPrefs.GetInt("Wave") == 3)
        {
            PlayerPrefs.SetInt("Wave", 4);
            SceneManager.LoadScene(6);
        }else if (PlayerPrefs.GetInt("Wave") == 4)
        {
            PlayerPrefs.SetInt("Wave", 5);
            SceneManager.LoadScene(7);
        } else
        {
            PlayerPrefs.SetInt("Wave", 6);
            SceneManager.LoadScene(8);
        }

        
    }

    public void MainMenu()
    {
        but.PlayOneShot(buttonClick);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
