using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    bool canFire = true;
    private void Start()
    {
        player = GetComponent<LevelManager>().player;
    }
    void Update()
    {
        float speed = player.GetComponent<ClownFish>().speed;
        if (Input.GetMouseButtonDown(0) && canFire && GetComponent<LevelManager>().bulletOn)
        {
            
            StartCoroutine(delay());
        }
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.up *Time.deltaTime * speed);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.GetComponent<ClownFish>().direction = true;
            player.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.GetComponent<ClownFish>().direction = false;
            player.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
    }

    IEnumerator delay()
    {
        canFire = false;
        Instantiate(bullet, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
}
