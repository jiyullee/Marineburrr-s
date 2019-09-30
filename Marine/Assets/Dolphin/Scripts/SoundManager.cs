using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip shoot;
    public AudioClip click;
    public AudioClip gameToDialog;
    public AudioClip introToMain;
    public AudioClip minus;
    public AudioClip plus;
    public AudioClip jump;
    public AudioClip slide;

    public void TurnOnClickSound()
    {
        GetComponent<AudioSource>().clip = click;
        GetComponent<AudioSource>().Play();
    }
    public void TurnOnGameToDialogSound()
    {
        GetComponent<AudioSource>().clip = gameToDialog;
        GetComponent<AudioSource>().Play();
    }
    public void TurnOnPlusSound()
    {
        GetComponent<AudioSource>().clip = plus;
        GetComponent<AudioSource>().Play();
    }
    public void TurnOnMinusSound()
    {
        GetComponent<AudioSource>().clip = minus;
        GetComponent<AudioSource>().Play();
    }
    public void TurnOnIntroToMainSound()
    {
        GetComponent<AudioSource>().clip = introToMain;
        GetComponent<AudioSource>().Play();
    }
    public AudioClip GetShootSound()
    {
        return shoot;
       
    }
    public AudioClip GetJumpSound()
    {
        return jump;

    }
    public AudioClip GetSlideSound()
    {
        return slide;

    }
}
