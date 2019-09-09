using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_InputManager : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float speed = player.GetComponent<Dolphin>().speed;
      
        if (Input.GetKey(KeyCode.A))
        {
            player.GetComponent<Dolphin>().direction = true;
            player.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.GetComponent<Dolphin>().direction = false;
            player.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

    }
    
}
