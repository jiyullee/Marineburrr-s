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
    Dolphin_LevelManager dolphin_LevelManager;
    void Start()
    {
        dolphin_LevelManager = GetComponent<Dolphin_LevelManager>();
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
            // 64 98
            if (time >= 64.0f && loadTutorial)
            {
                isChange = true;                               
                StartCoroutine(LoadTutorial());
            }
            else if (time >= 98.0f)
            {
                main.dolphin = true;
                if (main.level == 1)
                    main.levelUp();
               
                StartCoroutine(GameOver());
                
            }
           
            yield return null;
        }


    }


    IEnumerator LoadTutorial()
    {
        dolphin_LevelManager.DestroyRings();
        tutorialObject.SetActive(true);
        Time.timeScale = 0;
        audioSource.Pause();           
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
        soundManager.TurnOnClickSound();
        audioSource.Play();
        Time.timeScale = 1;
        tutorialObject.SetActive(false);
    }
    IEnumerator GameOver()
    {
        if (PlayerPrefs.GetInt("DolphinScore") < dolphin_LevelManager.GetScore())
        {
            PlayerPrefs.SetInt("DolphinScore", dolphin_LevelManager.GetScore());
        }
        gameOverImage.SetActive(true);
        dolphin_LevelManager.player.GetComponent<Dolphin>().speed = 0;
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(nextSceneName);

    }
    public bool getIsChange()
    {
        return isChange;
    }
}
