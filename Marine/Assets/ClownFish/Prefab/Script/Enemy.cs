using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float lifeTime;
    public bool direction;
    public int decrease;
    public int increase;
    public int HP;
    GameObject service;
    Color color;
    Fish_EffectManager effectManager;
    AudioSource audioSource;
    public AudioClip minus;
    public AudioClip plus;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        color = GetComponent<SpriteRenderer>().color;
        service = GameObject.FindGameObjectWithTag("Service");
        effectManager = service.GetComponent<Fish_EffectManager>();
    }
    private void OnEnable()
    {
        StartCoroutine(DisableSelf());
    }
   
   
    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(lifeTime);
        for (float i = 1f; i >= 0; i -= 0.02f)
        {          
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
        }
        Instantiate(effectManager.GetDead_Effect(), transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void TurnOnPlusSound()
    {
        audioSource.clip = plus;
        audioSource.Play();
    }
    public void TurnOnMinusSound()
    {
        audioSource.clip = minus;
        audioSource.Play();
    }
    private void OnDisable()
    {
        Instantiate(effectManager.GetDead_Effect(), transform.position, Quaternion.identity);
    }
}
