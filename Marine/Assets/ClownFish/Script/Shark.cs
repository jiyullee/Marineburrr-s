using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Enemy
{
    private void Update()
    {
        if(direction)
        {
            transform.rotation = new Quaternion(0,0,0,0);
        }
        else
        {
            transform.rotation = new Quaternion(0,180,0,0);
        }
    }
}
