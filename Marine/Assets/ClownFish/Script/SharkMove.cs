using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMove : MonoBehaviour
{
    public float speed;

    private void Update()
    {      
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }

}
