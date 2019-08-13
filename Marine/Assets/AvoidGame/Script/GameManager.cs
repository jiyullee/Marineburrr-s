using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    [SerializeField] int increaseAmount = 5;
    [SerializeField] GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        Score += increaseAmount;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
        

    }
    public void ReGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("AvoidGame");
    }
    public void BacktotheMainmenu()
    {

    }
}
