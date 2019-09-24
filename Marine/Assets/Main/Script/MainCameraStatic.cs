using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraStatic : MonoBehaviour
{
    float xPos;
    GameObject mainSaver;
    [SerializeField] float[] limit;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        
        mainSaver = GameObject.FindGameObjectWithTag("Main");
        level = mainSaver.GetComponent<Main>().level;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        xPos = Mathf.Clamp(transform.position.x, 2, limit[level-1]);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
