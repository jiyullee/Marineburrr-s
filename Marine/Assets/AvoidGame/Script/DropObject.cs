using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DropObject : MonoBehaviour
{
    public GameObject service;
    float speed = 1;
    int level = 1;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void Update()
    {
        transform.Translate(Vector3.down * 0.1f * speed);
        int score = service.GetComponent<GameManager>().Score;
        if(score/100 >= level)
        {
            level += 1;
            speed += 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print(speed);
        if (collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collider.tag == "Player")
        {
            Function();
            Destroy(gameObject);
        }
    }

    abstract public void Function();
}
