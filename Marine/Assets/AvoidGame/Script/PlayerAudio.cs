using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioClip pointUp;
    [SerializeField] AudioClip pointDown;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "SeaWeeds")
        {
            GetComponent<AudioSource>().clip = pointUp;
            StartCoroutine(Play());
        }
        else if (collider.tag == "Trash" )
        {
            if (collider.gameObject.GetComponent<Trash>().canCrash == true)
            {
                GetComponent<AudioSource>().clip = pointDown;
                StartCoroutine(Play());
                StartCoroutine(TurnRed());
            }
        }
    }

    IEnumerator Play()
    {
        GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(0.01f);
        GetComponent<AudioSource>().enabled = true;
    }
    IEnumerator TurnRed()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i < 5)
            {
                GetComponent<SpriteRenderer>().color -= new Color(0, 0.1f, 0.1f, 0);
            }
            else if (i >= 5)
            {
                GetComponent<SpriteRenderer>().color += new Color(0, 0.1f, 0.1f, 0);
            }
            yield return new WaitForSeconds(0.025f);
        }
    }

}
