using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] TMP_Text timerText;

    int minutes = 2;
    int seconds = 60;
    float x = 1;



    void Start()
    {
        Time.timeScale = 1;
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            OptionsButton();
        }

        TimerGame();
        timerText.SetText(minutes + ":" + seconds);
    }

    public void OptionsButton()
    {
        if (optionsCanvas.activeInHierarchy) 
        {
             optionsCanvas.SetActive(false);
             Time.timeScale = 1;
        }
        else
        {
            optionsCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeButton() 
    {
        optionsCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    void TimerGame()
    {


        x -= Time.deltaTime;
        if (x < 0)
        {
            seconds -= 1;
            x = 1;
        }

        if (seconds < 0)
        {
            minutes--;
            seconds = 59;
            if (minutes < 0)
            {
                Lose();
            }
        }
        
    }

    public void Win()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0;
    }

}
