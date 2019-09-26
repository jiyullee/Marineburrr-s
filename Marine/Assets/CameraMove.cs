using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float speed = player.GetComponent<Dolphin>().speed;
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
