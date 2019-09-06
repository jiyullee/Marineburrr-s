using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GetComponent<LevelManager>().player;
    }
    void Update()
    {
        float speed = player.GetComponent<ClownFish>().speed;
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.up *Time.deltaTime * speed);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.GetComponent<ClownFish>().direction = true;
            player.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.GetComponent<ClownFish>().direction = false;
            player.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
