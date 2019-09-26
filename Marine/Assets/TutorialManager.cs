using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    float time;
    public GameObject tutorialObject;
    FoodManager foodManager;
    bool isChange = false;
    void Start()
    {
        foodManager = GetComponent<FoodManager>();
        StartCoroutine(LoadTutorial());
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
           
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= 10.0f)
        {
            isChange = true;
        }
           
    }

    public bool getIsChange()
    {
        return isChange;
    }
}
