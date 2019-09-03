using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayerMove : MonoBehaviour
{
    Vector3 touchPos;
    Vector2 pos;
    [SerializeField] float speed;
    Vector3 destination;


    // Start is called before the first frame update
    private void Start()
    {
        destination = transform.position;
       //gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPos"), transform.position.y, transform.position.z);
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
                SceneManager.LoadScene("AvoidGame");
            }
            else if(hit.collider.gameObject.tag == "Fish")
            {
                SceneManager.LoadScene("WhiteClownfish");
            }
            else
            {
                destination = new Vector3(pos.x, transform.position.y, transform.position.z);
            }
        }
    }
}
