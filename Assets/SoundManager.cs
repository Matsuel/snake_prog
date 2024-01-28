using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void CutSound()
    {
        GameObject musique = GameObject.FindGameObjectWithTag("Music");
        if (musique != null)
        {
            if (musique.GetComponent<AudioSource>().isPlaying)
            {
                musique.GetComponent<AudioSource>().Stop();
            }
            else
            {
                musique.GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            Debug.Log("No music found");
        }
    }
}
