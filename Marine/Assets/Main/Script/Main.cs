using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{
    public Vector3 playerPos;
    public int level = 1;
    GameObject service;
    public bool dolphin = false;
    public bool turtle = false;
    public bool crownFish = false;
    // Start is called before the first frame update
    private void Awake()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        if (GameObject.FindGameObjectWithTag("Main") == null)
        {
            DontDestroyOnLoad(gameObject);
            gameObject.tag = "Main";
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void levelUp()
    {
        level += 1;
    }

    public Vector3 SavePlayerPos(Vector3 Pos)
    {
        playerPos = Pos;
        return Pos;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Main", 0);
    }

}
