using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownFish : MonoBehaviour
{
    GameObject service;
    public bool direction;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Shark")
        {
            service.GetComponent<LevelManager>().score -= collider.GetComponent<Enemy>().decrease;
        }
        else if (collider.gameObject.tag == "Food")
        {
            service.GetComponent<LevelManager>().score += collider.GetComponent<Food>().increase;
            Destroy(collider.gameObject);
        }
    }

}
