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
    SoundManager soundManager;
    bool isCrash;
    bool isDownScore;
    bool isScore;
    public AudioClip increaseAudio;
    public AudioClip decreaseAudio;
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();       
        service = GameObject.FindGameObjectWithTag("Service");
        prevPos = transform.position;
        tutorialManager = service.GetComponent<TutorialManager>();
        effectManager = service.GetComponent<Dolphin_EffectManager>();
        soundManager = service.GetComponent<SoundManager>();
        if (tutorialManager.getIsChange())
            rand = Random.Range(80, 400);
        else
            rand = Random.Range(80, 700);
    }
    private void Start()
    {
        StartCoroutine(Slerp());
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, rand, 1000),0);
    }
    IEnumerator Slerp()
    {
        while (true)
        {
            float xRand = Random.Range(-10, 0);
            float yRand = Random.Range(-10, 0);
            transform.position = Vector3.Slerp(transform.position, transform.position + new Vector3(xRand, yRand, 0), 2.0f);
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
            soundManager.TurnOnPlusSound();


            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Player" && tutorialManager.getIsChange() && !isDownScore)
        {
            isCrash = true;
            isScore = true;
            isDownScore = true;
            audioSource.clip = decreaseAudio;
            audioSource.Play();

            StartCoroutine(ChangeColor(collider.gameObject));
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
    IEnumerator ChangeColor(GameObject player)
    {
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(190, 0, 0, 255);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(255, 255, 255, 255);
    }
}
