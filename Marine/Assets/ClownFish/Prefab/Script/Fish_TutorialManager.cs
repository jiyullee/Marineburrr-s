using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fish_TutorialManager : MonoBehaviour
{
    float time;
    public GameObject tutorialObject;
    Main main;
    bool bulletOn;
    public string nextSceneName;
    public GameObject gameOverImage;
    SoundManager soundManager;
    public GameObject gameAudioObject;
    AudioSource audioSource;
    public GameObject shootButton;
    bool loadTutorial = true;
    public Canvas canvas;
    LevelManager levelManager;
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        audioSource = gameAudioObject.GetComponent<AudioSource>();
        soundManager = GetComponent<SoundManager>();       
      //  main = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
        StartCoroutine(TimeCheck());
    }

    IEnumerator TimeCheck()
    {
        while (true)
        {
            time += Time.deltaTime;
            //61 98
            if (time >= 61.0f && loadTutorial)
            {
                bulletOn = true;
                StartCoroutine(LoadTutorial());
            }
            else if (time >= 98.0f)
            {
                StartCoroutine(GameOver());
                main.crownFish = true;
                SceneManager.LoadScene(nextSceneName);
            }
           
            yield return null;
        }
        
        
    }
    IEnumerator LoadTutorial()
    {
        tutorialObject.SetActive(true);
        canvas.GetComponent<Canvas>().sortingOrder = 6;
        Time.timeScale = 0;
        audioSource.Pause();
        loadTutorial = false;
        yield return null;
       // StartCoroutine(DisableImage());
    }
    /*
    IEnumerator DisableImage()
    {
        while (true)
        {
            yield return null;           
            if (Input.GetKeyDown(KeyCode.S))
            {
                soundManager.TurnOnClickSound();
                Time.timeScale = 1;
                shootButton.SetActive(true);
                audioSource.Play();
                tutorialObject.SetActive(false);
                break;
            }

        }
    }
    */
    public void PlayButton()
    {
        soundManager.TurnOnClickSound();
        Time.timeScale = 1;
        shootButton.gameObject.SetActive(true);
        tutorialObject.SetActive(false);
        canvas.GetComponent<Canvas>().sortingOrder = 0;
    }

    IEnumerator GameOver()
    {
        if (PlayerPrefs.GetInt("FishScore") < levelManager.GetScore())
        {
            PlayerPrefs.SetInt("FishScore", levelManager.GetScore());
        }
        gameOverImage.SetActive(true);
        yield return new WaitForSeconds(5.0f);

    }

    public bool GetBulletOn()
    {
        return bulletOn;
    }
}
