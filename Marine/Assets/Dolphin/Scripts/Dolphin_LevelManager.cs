using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject ring;
    public float ringDelay;
    private void Start()
    {
        StartCoroutine(SpawnRing());
    }
    void Awake()
    {
        player = Instantiate(playerPrefab);
    }

    IEnumerator SpawnRing()
    {
        while (true)
        {
            int rand = Random.Range(0, 101);
            if(rand <= 20)
            {
                Instantiate(ring, player.transform.position + new Vector3 (-20, 20, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(ringDelay);
        }
    }

  
}
