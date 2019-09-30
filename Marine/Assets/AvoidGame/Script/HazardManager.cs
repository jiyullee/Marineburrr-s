using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    [SerializeField] GameObject[] dropObjects;
    int specialDelay = 76;
    float delay = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropObjects());
        StartCoroutine(ChangeCollider());
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
            Instantiate(dropObjects[Random.Range(0, dropObjects.Length)],new Vector3(Random.Range(-7.7f,7.7f),6,0),transform.rotation);
        }
    }
    IEnumerator ChangeCollider()
    {
        yield return new WaitForSeconds(specialDelay);
        for(int i = 0; i < dropObjects.Length; i++)
        {
            print(i);
            dropObjects[i].GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }
}
