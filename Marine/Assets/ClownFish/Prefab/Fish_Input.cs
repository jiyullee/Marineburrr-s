using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Input : MonoBehaviour
{
    public GameObject bullet;
    Fish_JoyStick joyStick;
    Fish_TutorialManager fish_TutorialManager;
    Vector3 _moveVector;
    public float moveSpeed;
    Transform _transform;
    bool canFire = true;
    void Awake()
    {
        _transform = transform;
        _moveVector = Vector3.zero;
        joyStick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<Fish_JoyStick>();
        fish_TutorialManager = GameObject.FindGameObjectWithTag("Service").GetComponent<Fish_TutorialManager>();
    }

    void Update()
    {
        HandleInput();
       
    }
    private void FixedUpdate()
    {
        Move();
       /*
        else if (Input.GetMouseButtonDown(1))
        {
            if (canFire && fish_TutorialManager.GetBulletOn())
                StartCoroutine(delay());
        }
        */
    }
    IEnumerator delay()
    {
        canFire = false;
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }

    public void HandleInput()
    {
        _moveVector = PoolInput();
    }
    public Vector3 PoolInput()
    {
        float h = joyStick.GetComponent<Fish_JoyStick>().GetHorizontalValue();
        float v = joyStick.GetComponent<Fish_JoyStick>().GetVerticalValue();
        if(h < 0)
        {
            GetComponent<ClownFish>().setDirection(true);
        }
        else if(h > 0)
        {
            GetComponent<ClownFish>().setDirection(false);
        }
        Vector3 moveDir = new Vector3(h, v, 0).normalized;
        return moveDir;
    }

    public void Move()
    {
        _transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }


}
