using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip buttonPress;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        aud.PlayOneShot(buttonPress);
        SceneManager.LoadScene(2);
    }

    public void PowerUp()
    {
        aud.PlayOneShot(buttonPress);
        SceneManager.LoadScene(9);
    }

    public void QuitGame()
    {
        aud.PlayOneShot(buttonPress);
        Application.Quit();
    }
}
