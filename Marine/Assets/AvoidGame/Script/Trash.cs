using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : DropObject
{
    public bool crush;
    public override GameObject Function(GameObject player)
    {
        player.GetComponent<TextControll>().SpawnMinus();
        service.GetComponent<AvoidGameManager>().DecreaseScore();
        return player;
    }
}
