using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_TutorialManager : MonoBehaviour
{
    float time;
    public GameObject tutorialObject;
    bool isChange = false;
    Main main;
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
            if (isChange)
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
            if(Input.touchCount > 0)
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
        if (time >= 105.0f)
        {
            isChange = true;
        }
        if (time >= 120.0f)
        {
            main.crownFish = true;           
            main.LoadScene();
        }

    }

    public bool getIsChange()
    {
        return isChange;
    }
}
