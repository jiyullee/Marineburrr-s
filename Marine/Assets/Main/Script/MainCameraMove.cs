using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("CameraPos"), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
      
   
        transform.position = player.transform.position + new Vector3(3.63f, 2.4f, -10);
        //if(transform.position.x != xPos)
        //{
        //    transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        //}
    }
}
