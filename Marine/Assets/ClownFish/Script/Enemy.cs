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
    private void Awake()
    {
        service = GameObject.FindGameObjectWithTag("Service");

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
}
