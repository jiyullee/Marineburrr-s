using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 startPos = Vector3.zero;
    Vector3 endPos = Vector3.zero;

   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * player.GetComponent<PlayerMove>().speed);
            player.GetComponent<Animator>().SetBool("Left", true);
            player.GetComponent<Animator>().SetBool("Right", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * player.GetComponent<PlayerMove>().speed);
            player.GetComponent<Animator>().SetBool("Right", true);
            player.GetComponent<Animator>().SetBool("Left", false);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("Right", false);
            player.GetComponent<Animator>().SetBool("Left", false);
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
                float delection = touchPos.x - startPos.x;
                diffpos = new Vector3(touchPos.x - startPos.x, 0.0f, 0.0f);
                if(delection < 0)
                {
                    player.GetComponent<Animator>().SetBool("Left", true);
                    player.GetComponent<Animator>().SetBool("Right", false);
                }
                else if (delection > 0)
                {
                    player.GetComponent<Animator>().SetBool("Left", false);
                    player.GetComponent<Animator>().SetBool("Right", true);
                }
                startPos = touchPos;
                player.transform.position += diffpos / 50;
            }
        }
    }
}
