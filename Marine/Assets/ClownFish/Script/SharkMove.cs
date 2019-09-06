using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMove : MonoBehaviour
{
    float xPos;
    float yRot;
    public float speed;

 
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
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }

}
