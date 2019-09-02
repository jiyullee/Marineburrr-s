using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float xPos;
    float yPos;
    float yRot;
    float a = 0;
    public float speed;
    bool leftReverse = true;
    bool rightReverse = true;

    private void Update()
    {
        xPos = transform.position.x;

        yRot = transform.rotation.y;
        if(xPos >= 400.0f)
            transform.Rotate(Vector2.up * Time.deltaTime * 30);
        else if(xPos <= -400.0f)
            transform.Rotate(Vector2.up * Time.deltaTime * 30);
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }
         
   
}
