using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
 
    public GameObject player;
    public List<GameObject> mainSaver = new List<GameObject>();

    private void Start()
    {
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
