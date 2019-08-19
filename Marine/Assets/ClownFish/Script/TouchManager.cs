using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    Vector3 startPos = Vector3.zero;
    Vector3 endPos = Vector3.zero;
    public float playerSpeed;
    private void Start()
    {
        player = GetComponent<LevelManager>().player;
    }
    void Update()
    {
        int touchCount = Input.touchCount;
        if(touchCount > 0)
        {
            if (touchCount == 1)
                PlayerMove();
            if (touchCount == 2)
                Shoot();
        }
    }

    void PlayerMove()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 touchPos = touch.position;
        Vector3 diffpos;
        if (touch.phase == TouchPhase.Began)
        {
            startPos = touchPos;
        }
        if (touch.phase == TouchPhase.Moved)
        {
            diffpos = new Vector3(touchPos.x - startPos.x, touchPos.y - startPos.y, 0.0f);
            startPos = touchPos;
            print(diffpos);
            player.transform.position += diffpos;
        }
    }

    void Shoot()
    {
        Touch touch = Input.GetTouch(1);
        Transform playerPos = player.transform;
        Instantiate(bullet, playerPos.position, playerPos.rotation);

    }
}
