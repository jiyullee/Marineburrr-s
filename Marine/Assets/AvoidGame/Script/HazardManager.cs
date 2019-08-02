using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    [SerializeField] GameObject[] dropObjects;
    float delay = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DropObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(dropObjects[Random.Range(0, dropObjects.Length)],new Vector3(Random.Range(-5.3f,5.3f),6,0),transform.rotation);
        }
    }
}
