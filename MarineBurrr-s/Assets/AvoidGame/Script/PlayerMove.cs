using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    float xPos;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        xPos = Mathf.Clamp(transform.position.x, -7.7f, 7.7f);
        transform.position = new Vector3(xPos,transform.position.y,transform.position.z);
    }
}
