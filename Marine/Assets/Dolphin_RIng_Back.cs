using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_RIng_Back : MonoBehaviour
{
    public bool isPass;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            isPass = true;
    }
}
