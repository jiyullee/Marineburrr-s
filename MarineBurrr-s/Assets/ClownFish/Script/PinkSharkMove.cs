using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkSharkMove : MonoBehaviour
{
    public float speed;
    Transform target;
    float a;
    float b;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 dir = target.position - transform.position;
        b = Mathf.Sign(dir.x);
    }

    private void Update()
    {

        bool direction = GetComponent<Enemy>().direction;
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
            transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;

            float a = Mathf.Sign(dir.x);
            if (a != b)
            {
                if (GetComponent<Enemy>().direction)
                {
                    GetComponent<Enemy>().direction = false;
                }
                else
                {
                    GetComponent<Enemy>().direction = true;
                }

                b = a;
            }
        }
    }
}
