using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoverLeft : MonoBehaviour
{
    [SerializeField] MainManager MainManager;
    bool activate = true;
    private void Update()
    {
       if(MainManager.player.transform.position.x > transform.position.x)
        {
            activate = false;
        }
        else
        {
            activate = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && activate ==true)
        {
            Camera.main.transform.position += new Vector3(18,0,0);
        }
    }
}
