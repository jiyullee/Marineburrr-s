using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkSharkMove : MonoBehaviour
{
    public float speed;
    Transform target;
    float a;
    float b;
    Color color;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 dir = target.position - transform.position;
        b = Mathf.Sign(dir.x);
        color = GetComponent<SpriteRenderer>().color;
        StartCoroutine(Follow());

        
    }

    IEnumerator FadeOut()
    {
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            print(1);
            Color col = new Vector4(1, 1, 1, i);
            GetComponent<SpriteRenderer>().color = col;
            yield return 0;
        }
       
    }

    IEnumerator Follow()
    {
        while (true)
        {
            yield return null;
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
                if (Mathf.Abs(dir.x) <= 5.0f  && Mathf.Abs(dir.y) <= 5.0f)
                {
                    for (float i = 1f; i >= 0; i -= 0.05f)
                    {
                        Color col = new Vector4(1, 1, 1, i);
                        GetComponent<SpriteRenderer>().color = col;
                       
                    }
                    Destroy(gameObject);
                }
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
}
