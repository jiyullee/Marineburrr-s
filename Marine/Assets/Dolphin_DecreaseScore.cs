using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_DecreaseScore : MonoBehaviour
{
  
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "CheckScore")
        {
            gameObject.GetComponentInParent<Ring>().ChangeisReach();
        }
    }
}
