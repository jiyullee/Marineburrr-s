using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager2 : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GetComponent<LevelManager>().player;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * player.GetComponent<ClownFishMove>().speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * player.GetComponent<ClownFishMove>().speed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.up * player.GetComponent<ClownFishMove>().speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.down * player.GetComponent<ClownFishMove>().speed);
        }
    }
}
