using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownFishMove : MonoBehaviour
{
    float xPos;
    float yRot;
    public float speed;
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -640.0f, 640.0f), Mathf.Clamp(transform.position.y, -360.0f, 360.0f), 0);
        
    }

  
}
