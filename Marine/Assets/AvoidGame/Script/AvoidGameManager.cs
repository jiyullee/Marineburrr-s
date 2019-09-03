using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvoidGameManager : MonoBehaviour
{
    public int Score;
    [SerializeField] int increaseAmount = 5;
    [SerializeField] int decreaseAmount = 10;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject Main;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Main = GameObject.FindGameObjectWithTag("Main");
    }

    // Update is called once per frame
    void Update()
    {
        if(Score < 0)
        {
            Score = 0;
        }
    }

    public void IncreaseScore()
    {
        Score += increaseAmount;
    }
    public void DecreaseScore()
    {
        Score -= decreaseAmount;
    }
    public void GameOver()
    {
        //if(Main.GetComponent<MainManager>().level == 2)
        //{
        //    Main.GetComponent<MainManager>().level += 1;
        //}
        SceneManager.LoadScene("Main");


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
