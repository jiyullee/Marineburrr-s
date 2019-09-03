using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
 
    public GameObject player;
    public int level = 1;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
       
    }
    public void StartAvoidGame()
    {
        SceneManager.LoadScene("AvoidGame");
    }
    public void StartCrownFishGame()
    {
        SceneManager.LoadScene("WhiteClownfish");
    }
}
