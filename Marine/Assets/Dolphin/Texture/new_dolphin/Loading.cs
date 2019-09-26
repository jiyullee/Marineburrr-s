using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    public Image image;
    int p = 4;
    bool isDone;
    float time = 0.0f;
    AsyncOperation async_operation;

    void Start()
    {
        StartCoroutine(LoadScene("Dolphin"));
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
                image.fillAmount = async_operation.progress;
                yield return true;
            }
        }
    }
    private void Update()
    {
        time += Time.deltaTime / p;
        image.fillAmount = time;      
        if (0.3f <= image.fillAmount && image.fillAmount <= 0.5f)
            p = 12;
        else if (0.7f <= image.fillAmount && image.fillAmount <= 0.9f)
            p = 4;
        if (time >= 6.0f)
        {
            async_operation.allowSceneActivation = true;
        }
    }
}
