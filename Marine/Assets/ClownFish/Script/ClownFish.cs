using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClownFish : MonoBehaviour
{
    public Text score;
    public bool direction;
    public Animator left;
    public Animator right;
    GameObject service;
    bool canFire = true;
    private void Awake()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void Update()
    {
        if (direction)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(false);
        }
        else
        {
            right.gameObject.SetActive(true);
            left.gameObject.SetActive(false);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f, 1280.0f), Mathf.Clamp(transform.position.y, 0.0f, 720.0f), 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Food")
        {
            service.GetComponent<LevelManager>().IncreaseScore(collider.GetComponent<Food>().increase);
            Destroy(collider.gameObject);
        }   
        if(collider.gameObject.tag == "Enemy")
        {
            service.GetComponent<LevelManager>().DecreaseScore(collider.GetComponent<Enemy>().decrease);
        }
    }
    public bool getDirection()
    {
        return direction;
    }
    public void setDirection(bool b)
    {
        direction = b;
    }
}
