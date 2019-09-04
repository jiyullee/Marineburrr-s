using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkShark : Enemy
{
    Transform target;
    Transform enemy;
    bool firstSign;
    bool endSign;
    Vector2 dir;
    float a;
    float b;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;  
        b = Mathf.Sign(dir.x);
    }

    void Update()
    {
        if (direction)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {

            transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        if (target != null)
        {
            Vector2 dir = target.position - transform.position;
            transform.position += (target.position - transform.position).normalized * GetComponent<SharkMove>().speed * Time.deltaTime;
            
            dir = target.position - transform.position; 

            a = Mathf.Sign(dir.x);

            if (a != b)
            {
                if (direction)
                    direction = false;
                else
                    direction = true;
                b = a;
                
            }                          
        }
    }
}
