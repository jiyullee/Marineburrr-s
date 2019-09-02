using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
   public void StartAvoidGame()
    {
        SceneManager.LoadScene("AvoidGame");
    }
}
