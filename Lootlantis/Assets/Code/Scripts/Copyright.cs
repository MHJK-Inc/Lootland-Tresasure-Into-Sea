using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Copyright : MonoBehaviour
{

    public TMPro.TextMeshProUGUI text;
    bool upDown;
    byte color;
    float timer;
    float maxTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        color = 255;
        timer = maxTimer;
        text.faceColor = new Color32(255, 255, 255, color);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }

        flashingTitle();
    }

    private void flashingTitle() {
        if (timer != 0)
        {
            timer--;
        } else
        {
            timer = maxTimer;
            if(upDown == true)
            {
                if(color == 255)
                {
                    upDown = false;
                } else {
                    color++;
                }
            } else {
                if(color == 0)
                {
                    upDown = true;
                } else {
                    color--;
                }
            }
            text.faceColor = new Color32(255, 255, 255, color);
        }
    }
}
