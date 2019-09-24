using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_CheckScore : MonoBehaviour
{ 
    public int increase;
    public int decrease;
    Dolphin_LevelManager dolphin_LevelManager;
    private void Start()
    {
       
        dolphin_LevelManager = GameObject.FindGameObjectWithTag("Service").GetComponent<Dolphin_LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ring")
        {           
            if (!collider.gameObject.GetComponent<Ring>().GetIsReach())
            {
                dolphin_LevelManager.IncreaseScore(increase);
                           
            }              
            else{
                dolphin_LevelManager.DecreaseScore(decrease);
            }
               
        }
    }
}
