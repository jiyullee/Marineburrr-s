using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : MonoBehaviour
{
    public float speed;
    public bool direction;
    public Animator left;
    public Animator right;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //   transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.0f, 9.0f), Mathf.Clamp(transform.position.y, -5.0f, 5.0f));
        if (direction)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(false);
        }
        else
        {
            right.gameObject.SetActive(true);
            left.gameObject.SetActive(false);
        }

        
    }
}
