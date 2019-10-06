using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : DropObject
{
    public bool crush;
    public override void Function()
    {

        service.GetComponent<AvoidGameManager>().DecreaseScore();
    }
}
