using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayerMove : MonoBehaviour
{
    Vector3 touchPos;
    Vector2 pos;
    public float speed;
    public float originSpeed;
    Vector3 destination;
    [SerializeField] GameObject background;
    [SerializeField] GameObject fishConversation;
    [SerializeField] GameObject turtleConversation;
    [SerializeField] GameObject dolphinConversation;
    [SerializeField] GameObject service;
     GameObject mainSaver;


    // Start is called before the first frame update
    private void Start()
    {
        
        originSpeed = speed;
        mainSaver = GameObject.FindGameObjectWithTag("Main");
        gameObject.transform.position = mainSaver.GetComponent<Main>().playerPos;
        destination = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = transform.position.x - destination.x;

        if (distance < -0.2f)
        {
            transform.Translate(speed, 0, 0);
            GetComponent<Animator>().SetBool("Right", true);
            GetComponent<Animator>().SetBool("Left", false);
        }
        else if (distance > 0.2f)
        {
            transform.Translate(-speed, 0, 0);
            GetComponent<Animator>().SetBool("Left", true);
            GetComponent<Animator>().SetBool("Right", false);
        }
        else if (-0.2f <= distance && distance <= 0.2f)
        {
            transform.Translate(0, 0, 0);
            GetComponent<Animator>().SetBool("Right", false);
            GetComponent<Animator>().SetBool("Left", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            print("Touch");
            Ray2D ray = new Ray2D(pos, Vector3.forward);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider.gameObject.tag == "Turtle")
            {
                background.SetActive(true);
                speed = 0;
                turtleConversation.SetActive(true);
            }
            else if (hit.collider.gameObject.tag == "Fish")
            {
                background.SetActive(true);
                speed = 0;
                fishConversation.SetActive(true);
            }
            else if(hit.collider.gameObject.tag == "Dolphin")
            {
                background.SetActive(true);
                speed = 0;
               dolphinConversation.SetActive(true);
            }
            else if (hit.collider.gameObject.tag == "Map")
            {
                destination = new Vector3(pos.x, transform.position.y, transform.position.z);
            }
        }
    }
}
