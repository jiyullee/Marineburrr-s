using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerAnim : MonoBehaviour
{
    public bool direction = true;
    public Animator leftAnim;
    public Animator rightAnim;
    private void Update()
    {
        if (direction)
        {
            leftAnim.gameObject.SetActive(false);
            rightAnim.gameObject.SetActive(true);
        }
        else
        {
            leftAnim.gameObject.SetActive(true);
            rightAnim.gameObject.SetActive(false);
        }
            
    }

}
