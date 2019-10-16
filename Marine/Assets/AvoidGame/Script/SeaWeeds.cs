using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeeds : DropObject
{
 
   public override GameObject Function(GameObject player)
    {
        player.GetComponent<TextControll>().SpawnPlus();
        service.GetComponent<AvoidGameManager>().IncreaseScore();
        return player;
    }

    
}
