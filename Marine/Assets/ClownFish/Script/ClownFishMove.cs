using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownFishMove : MonoBehaviour
{
    float xPos;
    float yRot;
    public float speed;
<<<<<<< HEAD
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -640.0f, 640.0f), Mathf.Clamp(transform.position.y, -360.0f, 360.0f), 0);
        
    }

  
=======


    private void Update()
    {
        xPos = transform.position.x;
        yRot = transform.rotation.y;

        int direction = GetComponent<ClownFish>().direction;
        if (direction == -1)
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 1.0f, transform.rotation.z, transform.rotation.w);
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }

>>>>>>> 9262ccc841801f6bf52297417b19477d108a7aca
}
