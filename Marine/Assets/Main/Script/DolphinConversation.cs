using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DolphinConversation : MonoBehaviour
{
    [SerializeField] Sprite[] Conversations;
    [SerializeField] GameObject background;
    [SerializeField] GameObject player;
     GameObject mainSaver;
    int sceneNum = 0;

    void Start()
    {
        mainSaver = GameObject.FindGameObjectWithTag("Main");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = Conversations[sceneNum];
    }


    public void Next()
    {
        if (sceneNum == Conversations.Length - 1)
        {
            background.SetActive(false);
            sceneNum = 0;
            gameObject.SetActive(false);
            player.GetComponent<MainPlayerMove>().speed = player.GetComponent<MainPlayerMove>().originSpeed;
            mainSaver.GetComponent<Main>().SavePlayerPos(player.transform.position);
            SceneManager.LoadScene("Dolphin");

        }
        sceneNum += 1;
    }

    public void Before()
    {
        if (sceneNum > 0)
        {
            sceneNum -= 1;
        }
    }
}
