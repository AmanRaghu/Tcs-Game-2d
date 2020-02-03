using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool IsGameOver;
    public static GameManager Instance;
    public GameObject GameOverPanel;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    void Update()
    {
        if (IsGameOver == true)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (IsGameOver == false)
        {
            GameOverPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("main"); 
    }
    public void Quit()
    {
        Application.Quit();
    }
}
