using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading_Input : MonoBehaviour
{
    public Sprite loadingImage;
    public GameObject background;
   
    void Update()
    {
        int touchCount = Input.touchCount;
        if(touchCount > 0)
        {        
            background.GetComponent<Image>().sprite = loadingImage;           
        }
         
    }
}
