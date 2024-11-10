using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject optionsCanvas;

    void Start()
    {
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OptionsButton()
    {
        if (optionsCanvas.activeSelf) 
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
}
