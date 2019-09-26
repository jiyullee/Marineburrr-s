using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : MonoBehaviour
{
    GameObject service;
    public float speed;
    TutorialManager tutorialManager;
    private void Awake()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        tutorialManager = service.GetComponent<TutorialManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Food" && !tutorialManager.getIsChange())
        {
            service.GetComponent<Dolphin_LevelManager>().IncreaseScore(collider.GetComponent<Feed>().increase);
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.tag == "Food" && tutorialManager.getIsChange())
        {
            service.GetComponent<Dolphin_LevelManager>().DecreaseScore(collider.GetComponent<Feed>().decrease);
        }

    }
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

}
