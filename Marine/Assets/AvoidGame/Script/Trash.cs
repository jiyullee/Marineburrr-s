using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : DropObject
{
    

    public override void Function()
    {
        service.GetComponent<GameManager>().GameOver();
    }
}
