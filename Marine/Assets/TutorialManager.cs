using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    float time;
    public GameObject tutorialObject;
    FoodManager foodManager;
    bool isChange = false;
    Main main;
    public GameObject gameOverImage;
    public string nextSceneName;
    void Start()
    {
        foodManager = GetComponent<FoodManager>();
        StartCoroutine(LoadTutorial());
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
    }

    IEnumerator LoadTutorial()
    {
        while (true)
        {
            yield return null;
            if (isChange)
            {
                tutorialObject.SetActive(true);
                Time.timeScale = 0;
                for(int i = 0; i < foodManager.feedList.Count; i++)
                {
                    Destroy(foodManager.feedList[i]);
                }
                StartCoroutine(DisableImage());
                break;
            }
            
        }
    }

   IEnumerator DisableImage()
    {
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.S))
            {
                Time.timeScale = 1;
                tutorialObject.SetActive(false);
                break;
            }
            if(Input.touchCount > 0)
            {
                Time.timeScale = 1;
                tutorialObject.SetActive(false);
                break;
            }
           
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= 110.0f)
        {
            isChange = true;
        }
        if (time >= 141.0f)
        {
            main.dolphin = true;
            if (main.level == 1)
                main.levelUp();
            StartCoroutine(GameOver());
            SceneManager.LoadScene(nextSceneName);
        }

    }
    IEnumerator GameOver()
    {
        gameOverImage.SetActive(true);
        yield return new WaitForSeconds(3.0f);
   
    }
    public bool getIsChange()
    {
        return isChange;
    }
}
