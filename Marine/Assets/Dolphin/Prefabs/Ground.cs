using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public void Fallout()
    {
        transform.position = new Vector3(transform.position.x, 10, transform.position.z);
    }

    public void Bulge()
    {
        transform.position = new Vector3(transform.position.x, 60, transform.position.z);
    }
}
