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

    void Start()
    {
        StartCoroutine(LoadTutorial());
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
    }

    IEnumerator LoadTutorial()
    {
        while (true)
        {
            yield return null;
            if (bulletOn)
            {
                tutorialObject.SetActive(true);
                Time.timeScale = 0;
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
            if (Input.touchCount > 0)
            {
                Time.timeScale = 1;
                tutorialObject.SetActive(false);
                break;
            }
            if (Input.GetKeyDown(KeyCode.S))
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
        if (time >= 63.0f)
        {
            bulletOn = true;            
        }
        if (time >= 105.0f)
        {
            StartCoroutine(GameOver());
            main.crownFish = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    IEnumerator GameOver()
    {
        gameOverImage.SetActive(true);
        yield return new WaitForSeconds(3.0f);

    }

    public bool GetBulletOn()
    {
        return bulletOn;
    }
}
