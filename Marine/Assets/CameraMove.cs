using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject service;
    GameObject player;
    private void Awake()
    {
        player = service.GetComponent<Dolphin_LevelManager>().player;
    }
    void Update()
    {
        float speed = player.GetComponent<Dolphin>().speed;
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
