using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : Enemy
{
    
    private void Update()
    {
        if (HP <= 0)
        {
            service.GetComponent<LevelManager>().score += increase;
            Destroy(gameObject);
        }
       
    }
}
