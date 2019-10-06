using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int increase;
    public float lifeTime;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        StartCoroutine(DisableSelf());
    }

    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);

    }
    public void TurnOnPlusSound()
    {
        audioSource.Play();
    }
}