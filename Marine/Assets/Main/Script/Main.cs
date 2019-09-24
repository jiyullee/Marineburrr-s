using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Vector3 playerPos;
    public int level = 1;
    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        print(1);
    }

    public void levelUp()
    {
        level += 1;
    }

    public Vector3 SavePlayerPos(Vector3 Pos)
    {
        playerPos = Pos;
        return Pos;
    }

}
