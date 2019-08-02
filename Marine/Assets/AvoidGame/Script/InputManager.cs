using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject player;
    Vector3 startPos = Vector3.zero;
    Vector3 endPos = Vector3.zero;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * player.GetComponent<PlayerMove>().speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * player.GetComponent<PlayerMove>().speed);
        }
        
        
        //mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;
            Vector3 diffpos;
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touchPos;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                diffpos = new Vector3(touchPos.x - startPos.x, 0.0f, 0.0f);
                startPos = touchPos;
                player.transform.position += diffpos / 10;
            }
        }
    }
}
