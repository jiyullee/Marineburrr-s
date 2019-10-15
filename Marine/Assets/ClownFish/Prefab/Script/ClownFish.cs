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
    GameObject scoreVariation;
    private void Awake()
    {
        scoreVariation = GetComponentInChildren<ScoreVariationText>().gameObject;
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
            int increase = collider.GetComponent<Food>().increase;
            service.GetComponent<LevelManager>().IncreaseScore(increase);
            collider.gameObject.GetComponent<Food>().TurnOnPlusSound();
            StartCoroutine(ShowIncreaseScore(increase));
            Destroy(collider.gameObject);
        }   
        if(collider.gameObject.tag == "Enemy")
        {
            StartCoroutine(ChangeColor());
            collider.gameObject.GetComponent<Enemy>().TurnOnMinusSound();
            int decrease = collider.GetComponent<Enemy>().decrease;
            service.GetComponent<LevelManager>().DecreaseScore(decrease);
            StartCoroutine(ShowDecreaseScore(decrease));
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
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(255, 255, 255, 255);
    }
    IEnumerator ShowIncreaseScore(int increase)
    {
        scoreVariation.GetComponent<Text>().text = "+" + increase.ToString();
        scoreVariation.GetComponent<Text>().color = new Color(0, 0, 255, 255);
        scoreVariation.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        scoreVariation.GetComponent<Text>().text = "";
    }
    IEnumerator ShowDecreaseScore(int decrease)
    {
        scoreVariation.GetComponent<Text>().text = "-" + decrease.ToString();
        scoreVariation.GetComponent<Text>().color = new Color(255, 0, 0, 255);
        scoreVariation.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        scoreVariation.GetComponent<Text>().text = "";
    }
}
