using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DropObject : MonoBehaviour
{
    public GameObject service;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void Update()
    {
        transform.Translate(Vector3.down * 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collider.tag == "Player")
        {
            Function();
            Destroy(gameObject);
        }
    }
    abstract public void Function();
}
