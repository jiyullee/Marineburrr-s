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
    SpriteRenderer spriteRenderer;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        service = GameObject.FindGameObjectWithTag("Service");
        anim.SetBool("Left", true);
        anim.SetBool("Right", false);
    }
    private void Update()
    {
        if (direction)
        {
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
           
        }
        else
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", true);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f, 1280.0f), Mathf.Clamp(transform.position.y, 0.0f, 720.0f), 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Food")
        {
            service.GetComponent<LevelManager>().IncreaseScore(collider.GetComponent<Food>().increase);
            collider.gameObject.GetComponent<Food>().TurnOnPlusSound();
            Destroy(collider.gameObject);
        }   
        if(collider.gameObject.tag == "Enemy")
        {
            StartCoroutine(ChangeColor());
            collider.gameObject.GetComponent<Enemy>().TurnOnMinusSound();
            service.GetComponent<LevelManager>().DecreaseScore(collider.GetComponent<Enemy>().decrease);
            Destroy(collider.gameObject);
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
    IEnumerator ChangeColor()
    {
        spriteRenderer.color = new Color(190, 0, 0, 255);
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = new Color(255, 255, 255, 255);
    }
}
