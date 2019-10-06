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
 
    private void Update()
    {
     
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
 
}
