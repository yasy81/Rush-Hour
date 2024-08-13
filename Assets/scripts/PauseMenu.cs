using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    
    void Start()
    {
        Time.timeScale = 1f;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                play();
            }
            else
            {
                 stop();
            }
        }
    }

    void stop()
    {
        PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        Paused = true; 
    }

    public void play() 
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false; 
    } 

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
