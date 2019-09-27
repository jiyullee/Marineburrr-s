using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_RIng_Back : MonoBehaviour
{
    bool isCrash;
    bool isPass;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isCrash = true;
            isPass = true;
        }
            
    }
    public bool getIsCrash()
    {
        return isCrash;
    }
    public bool getIsPass()
    {
        return isPass;
    }
}
