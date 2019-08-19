using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishMove : MonoBehaviour
{
    public float rand;
    public float speed;
    Vector3[] directionArr = new Vector3[2];
    Vector3 direction;
    private void Start()
    {
        rand = Random.Range(0.0f, 0.7f);
        directionArr[0] = Vector3.forward;
        directionArr[1] = Vector3.back;
        direction = directionArr[Random.Range(0, 2)];
    }
    void Update()
    {
        float zRot = transform.rotation.z;
        if (zRot <= rand)
        {
            transform.Rotate(direction * Time.deltaTime * 30);
        }
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
