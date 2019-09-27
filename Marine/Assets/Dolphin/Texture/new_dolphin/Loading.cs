using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    public string nextSceneName;
    public GameObject backGround;
    Image backImage;
    public Image loadingBar;
    public Sprite loadingImage;
    public int p;
    public int p1;
    public int p2;
    public float pointA;
    public float pointB;
    public float pointC;
    public float pointD;
    bool isDone;
    float time = 0.0f;
    float ftime = 0;
    AsyncOperation async_operation;

    void Start()
    {
        backImage = backGround.GetComponent<Image>();
        StartCoroutine(LoadScene(nextSceneName));
    }
   
   
   IEnumerator LoadScene(string sceneName)
    {
        async_operation = SceneManager.LoadSceneAsync(sceneName);
        async_operation.allowSceneActivation = false;
        if (!isDone)
        {
            isDone = true;
            while(async_operation.progress < 0.9f)
            {
                loadingBar.fillAmount = async_operation.progress;
                yield return true;
            }
        }
    }
    private void Update()
    {
        time += Time.deltaTime / p;
        ftime += Time.deltaTime;
        loadingBar.fillAmount = time;      
        if (pointA <= loadingBar.fillAmount && loadingBar.fillAmount <= pointB)
            p = p1;
        else if (pointC <= loadingBar.fillAmount && loadingBar.fillAmount < pointD)
        {
            backImage.sprite = loadingImage;           
            p = p2;
        }      
        else if (loadingBar.fillAmount >= 1.0f)
        {
            async_operation.allowSceneActivation = true;
        }
    }
}
