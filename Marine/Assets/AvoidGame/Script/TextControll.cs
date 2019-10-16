using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControll : MonoBehaviour
{
    [SerializeField] GameObject plusUI;
    [SerializeField] GameObject minusUI;
    // Start is called before the first frame update
    
        public void SpawnPlus()
    {
        StartCoroutine(Plus());
    }

    public void SpawnMinus()
    {
        StartCoroutine(minus());
    }
    IEnumerator Plus()
    {
        plusUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        plusUI.SetActive(false);
    }
    IEnumerator minus()
    {
        minusUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        minusUI.SetActive(false);
    }
}
