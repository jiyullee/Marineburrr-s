using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_DecreaseScore : MonoBehaviour
{
    bool isCrash;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "CheckScore")
        {
            gameObject.GetComponentInParent<Ring>().ChangeisReach();
        }
        if (collider.gameObject.tag == "Player")
            isCrash = true;
    }

    public bool getIsCrash()
    {
        return isCrash;
    }
  
}
