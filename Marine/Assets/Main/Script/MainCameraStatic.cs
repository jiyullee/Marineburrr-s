using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraStatic : MonoBehaviour
{
    float xPos;
    GameObject service;
    GameObject mainSaver;
    [SerializeField] float[] limit;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        mainSaver = GameObject.FindGameObjectWithTag("Main");

        GameObject main = service.GetComponent<MainManager>().mainSaver[0];
        level = main.GetComponent<Main>().level;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        xPos = Mathf.Clamp(transform.position.x, 2, limit[level-1]);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
