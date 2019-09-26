using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    public int increase;
    public int decrease;
    GameObject service;
    Vector3 prevPos;
    float yPos;
    float rand;
    TutorialManager tutorialManager;
    void Awake()
    {
        rand = Random.Range(80, 700);
        service = GameObject.FindGameObjectWithTag("Service");
        prevPos = transform.position;
        tutorialManager = service.GetComponent<TutorialManager>();
    }
    private void Start()
    {
        StartCoroutine(Slerp());
    }
    private void Update()
    {
        if (tutorialManager.getIsChange())
            rand = 80;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, rand, 1000),0);
    }
    IEnumerator Slerp()
    {
        while (true)
        {
            transform.position = Vector3.Slerp(transform.position, transform.position + new Vector3(-3, -4, 0), 1.0f);
            if (transform.position.y <= rand)
                break;
            yield return null;
        }
    }
   
}
