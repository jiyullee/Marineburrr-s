using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DropObject : MonoBehaviour
{
    public GameObject service;
    int level = 1;
    [SerializeField] bool canCrash = true;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void Update()
    {
        int score = service.GetComponent<AvoidGameManager>().Score;
        if(score/100 >= level)
        {
            level += 1;
            GetComponent<Rigidbody2D>().gravityScale += 0.5f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trash" || collision.gameObject.tag == "Ground")
        {
            if(gameObject.tag == "Trash")
            canCrash = false;
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collider.tag == "Player" && canCrash == true)
        {
            Function();
            Destroy(gameObject);
        }
    }
   
    abstract public void Function();
}
