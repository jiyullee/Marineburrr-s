using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeeds : DropObject
{
 
   public override void Function()
    {
        service.GetComponent<GameManager>().IncreaseScore();
    }

    
}
