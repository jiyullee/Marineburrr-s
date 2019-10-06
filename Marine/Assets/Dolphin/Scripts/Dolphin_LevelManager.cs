using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dolphin_LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject ringPrefab;
    float xPos = 500.0f;
    float[] yPos = { 500.0f, 600.0f };
    public float ringDelay;
    public int score;
    public Text textScore;
    Main main;
    public Image FirstTutorialImage;
    public Image SecondTutorialImage;
    TutorialManager tutorialManager;
    SoundManager soundManager;
    List<GameObject> rings = new List<GameObject>();
    void Awake()
    {
        tutorialManager = GetComponent<TutorialManager>();
        player = Instantiate(playerPrefab);
        soundManager = GetComponentInChildren<SoundManager>();
        StartCoroutine(SpawnRing());
        //  main = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
    }

    IEnumerator SpawnRing()
    {
        while (true)
        {
            int rand = Random.Range(0, 101);
            if(rand <= 100)
            {
                int randYpos = Random.Range(0, 2);
                if(randYpos == 0)
                    rings.Add(Instantiate(ringPrefab, new Vector3(xPos, yPos[0], 0), Quaternion.identity));
                else
                    rings.Add(Instantiate(ringPrefab, new Vector3(xPos, yPos[1], 0), Quaternion.identity));
                xPos -= 600;
                if (tutorialManager.getIsChange())
                {
                    break;
                }
               
            }
            yield return new WaitForSeconds(ringDelay);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void DestroyRings()
    {
        for (int i = 0; i < rings.Count; i++)
            Destroy(rings[i]);
    }
    private void Update()
    {        
        textScore.text = score.ToString();
    }
    public void DecreaseScore(int n)
    {
        score -= n;
        if (score <= 0)
            score = 0;
    }
    public void IncreaseScore(int n)
    {
        score += n;        
    }
}
