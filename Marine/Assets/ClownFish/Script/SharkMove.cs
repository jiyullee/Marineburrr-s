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
        xPos = transform.position.x;

        yRot = transform.rotation.y;
        print(yRot);
        int direction = GetComponent<Shark>().direction;
        if (direction == -1)
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 1.0f, transform.rotation.z, transform.rotation.w);
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }

}
