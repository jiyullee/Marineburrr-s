using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    public string nextSceneName;
    bool isDone;
    float time = 0.0f;
    AsyncOperation async_operation;

    void Start()
    {
       // StartCoroutine(LoadScene(nextSceneName));
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
                async_operation.allowSceneActivation = true;
                yield return true;
            }
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 4.0f)
            SceneManager.LoadScene(nextSceneName);
    }
}
