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
    public GameObject service;
    Color color;
    private void Awake()
    {
        color = GetComponent<SpriteRenderer>().color;
        service = GameObject.FindGameObjectWithTag("Service");

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
       // Destroy(gameObject);
    }
}
