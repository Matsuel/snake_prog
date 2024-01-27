using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsCollider : MonoBehaviour
{
    public CreateBigmac createBigmac;
    public Movements snake;
    public Transform segment;
    public AudioSource boom;
    public AudioSource magic;
    public string mode = "ez";
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Objects"){
            Destroy(other.gameObject);
            snake.Grow();
            createBigmac.StartCoroutine(createBigmac.createBigmac());
            snake.score++;
        }else if(other.gameObject.tag == "Wall" && mode != "ez"){
            StartCoroutine(LoadScene());
        }else if (other.gameObject.tag == "Magic"){
            magic.Play();
            snake.score+=5;
            Destroy(other.gameObject);
            for (int i = 0; i < 5; i++)
            {
                snake.Grow();
            }
            createBigmac.StartCoroutine(createBigmac.createBigmac());
        }else if (other.gameObject.tag == "Sapeur"){
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
