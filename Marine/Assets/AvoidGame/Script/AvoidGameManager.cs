using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvoidGameManager : MonoBehaviour
{
    public int score;
    [SerializeField] int gameTime;
    [SerializeField] int increaseAmount = 5;
    [SerializeField] int decreaseAmount = 10;
    [SerializeField] GameObject ClearUI;
    [SerializeField] GameObject Main;
    [SerializeField] GameObject middleTutorial;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Main = GameObject.FindGameObjectWithTag("Main");
        StartCoroutine(BacktotheMainmenu());
        StartCoroutine(StartMiddleTutorial());
        //SceneManager.LoadScene("Main");

    }

    // Update is called once per frame
    void Update()
    {
        if(score < 0)
        {
            score = 0;
        }
    }

    public void IncreaseScore()
    {
        score += increaseAmount;
    }
    public void DecreaseScore()
    {
        score -= decreaseAmount;
    }
    public void GameOver()
    {
        //if(Main.GetComponent<MainManager>().level == 2)
        //{
        //    Main.GetComponent<MainManager>().level += 1;
        //}
        if(PlayerPrefs.GetInt("TurtleScore") < score)
        {
            PlayerPrefs.SetInt("TurtleScore", score);
        }
        SceneManager.LoadScene("Main");


    }
    public void ReGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("AvoidGame");
    }
    IEnumerator BacktotheMainmenu()
    {
        yield return new WaitForSeconds(gameTime);
     
            if (Main.GetComponent<Main>().level == 2)
            {
                Main.GetComponent<Main>().level += 1;
            }
            Main.GetComponent<Main>().turtle = true;
            if (PlayerPrefs.GetInt("TurtleScore") < score)
            {
                PlayerPrefs.SetInt("TurtleScore", score);
            }
            ClearUI.SetActive(true);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Turtle_LoadingScene 2");


        

    }
    IEnumerator StartMiddleTutorial()
    {
        yield return new WaitForSeconds(71);
        middleTutorial.SetActive(true);
    }
}
