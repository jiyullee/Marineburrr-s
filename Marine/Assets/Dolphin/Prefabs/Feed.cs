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
    Dolphin_EffectManager effectManager;
    bool isCrash;
    bool isDownScore;
    bool isScore;
    void Awake()
    {
        rand = Random.Range(80, 700);
        service = GameObject.FindGameObjectWithTag("Service");
        prevPos = transform.position;
        tutorialManager = service.GetComponent<TutorialManager>();
        effectManager = service.GetComponent<Dolphin_EffectManager>();
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && !tutorialManager.getIsChange() && !isScore)
        {
            isCrash = true;
            isScore = true;
            isDownScore = true;
            Instantiate(effectManager.GetEat_Effect(), transform.position, Quaternion.identity);
            service.GetComponent<Dolphin_LevelManager>().IncreaseScore(increase);
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Player" && tutorialManager.getIsChange() && !isDownScore)
        {
            isCrash = true;
            isScore = true;
            isDownScore = true;
            service.GetComponent<Dolphin_LevelManager>().DecreaseScore(decrease);
        }       
    }
    public bool getIsCrash()
    {
        return isCrash;
    }
    public bool getIsScore()
    {
        return isScore;
    }
    public bool getIsDownScore()
    {
        return isDownScore;
    }
}
