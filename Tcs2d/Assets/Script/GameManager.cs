using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool IsGameOver;
    public static GameManager Instance;
    public GameObject GameOverPanel;

    public bool IsPhase2Active;
    public GameObject Phase2;

    public bool BossFight;
    public GameObject BossText;

    public GameObject Boss;
    public GameObject BossHealth;
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
            Phase2.SetActive(false);
            BossText.SetActive(false);
        }
        else if (IsGameOver == false)
        {
            GameOverPanel.SetActive(false);
            Time.timeScale = 1f;
        }

        //Phase2Check
        if (IsPhase2Active == true)
        {
            Phase2.SetActive(true);
            
        }
        if (IsPhase2Active == false)
        {
            Phase2.SetActive(false);
        }

        if (BossFight == true)
        {
            BossText.SetActive(true);
            Phase2.SetActive(false);
            StartCoroutine(Bosshave());
            BossHealth.SetActive(true);
        }
        if (BossFight == false)
        {
            BossText.SetActive(false);
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

    IEnumerator Bosshave()
    {
        yield return new WaitForSeconds(2f);
        Boss.SetActive(true);
    }
}
