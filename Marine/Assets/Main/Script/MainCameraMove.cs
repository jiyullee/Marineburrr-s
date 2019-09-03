using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    float xPos;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("CameraPos"), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        xPos = Mathf.Clamp(transform.position.x, 0, 93.4f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
