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
    SoundManager soundManager;
    public GameObject gameAudioObject;
    AudioSource audioSource;
    bool loadTutorial = true;
    void Start()
    {
        audioSource = gameAudioObject.GetComponent<AudioSource>();
        soundManager = GetComponentInChildren<SoundManager>();
        foodManager = GetComponent<FoodManager>();
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
        StartCoroutine(TimeCheck());
    }

    IEnumerator TimeCheck()
    {
        while (true)
        {
            time += Time.deltaTime;
            // 110 141
            if (time >= 110.0f && loadTutorial)
            {
                isChange = true;                
                StartCoroutine(LoadTutorial());
            }
            else if (time >= 141.0f)
            {
                main.dolphin = true;
                if (main.level == 1)
                    main.levelUp();
                StartCoroutine(GameOver());
                SceneManager.LoadScene(nextSceneName);
            }
           
            yield return null;
        }


    }


    IEnumerator LoadTutorial()
    {
        tutorialObject.SetActive(true);
        Time.timeScale = 0;
        audioSource.Pause();
        for (int i = 0; i < foodManager.feedList.Count; i++)
        {
            Destroy(foodManager.feedList[i]);
        }     
        loadTutorial = false;
        yield return null;
    }
    /*
   IEnumerator DisableImage()
    {
        while (true)
        {
            yield return null;            
            if (Input.GetKeyDown(KeyCode.S))
            {
                audioSource.Play();
                Time.timeScale = 1;
                tutorialObject.SetActive(false);
                break;
            }         
           
        }
    }
    */
    public void PlayButton()
    {
        audioSource.Play();
        Time.timeScale = 1;
        tutorialObject.SetActive(false);
    }
    IEnumerator GameOver()
    {
        gameOverImage.SetActive(true);
        yield return new WaitForSeconds(5.0f);
   
    }
    public bool getIsChange()
    {
        return isChange;
    }
}
