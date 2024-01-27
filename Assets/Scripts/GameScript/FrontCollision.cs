using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrontCollision : MonoBehaviour
{
    public AudioSource boom;
    public Transform segment;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Segment" && this.gameObject.tag=="Front"){
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene(){
        boom.Play();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(boom.clip.length);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
