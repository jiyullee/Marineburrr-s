using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{
    public float lifeTime;
    public float speed;
    GameObject player;
    bool direction;
    GameObject service;
    LevelManager levelManager;
    SoundManager soundManager;
    AudioSource audioSource;
    Fish_EffectManager effectManager;
    GameObject scoreVariation;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        service = GameObject.FindGameObjectWithTag("Service");
        levelManager = service.GetComponent<LevelManager>();
        soundManager = service.GetComponent<SoundManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        effectManager = service.GetComponent<Fish_EffectManager>();
        scoreVariation = player.GetComponentInChildren<ScoreVariationText>().gameObject;
    }
    private void OnEnable()
    {
        audioSource.Play();
        direction = player.GetComponent<ClownFish>().direction;
        StartCoroutine(DisableSelf());
    }

    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {    
        if(direction)
             transform.Translate(Vector3.left * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collider.GetComponent<Enemy>().HP--;
            if(collider.GetComponent<Enemy>().HP == 0)
            {
                Instantiate(effectManager.GetDead_Effect(), transform.position, Quaternion.identity);
                int increase = collider.GetComponent<Enemy>().increase;
                levelManager.IncreaseScore(increase);
                StartCoroutine(ShowIncreaseScore(increase));
                Destroy(collider.gameObject);
            }
        }
    }
   
    IEnumerator ShowIncreaseScore(int increase)
    {
        scoreVariation.GetComponent<Text>().text = "+" + increase.ToString();
        scoreVariation.GetComponent<Text>().color = new Color(0, 0, 255, 255);
        scoreVariation.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        scoreVariation.GetComponent<Text>().text = "";
    }
}
