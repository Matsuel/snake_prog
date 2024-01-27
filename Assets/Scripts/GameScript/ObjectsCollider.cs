using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsCollider : MonoBehaviour
{
    public CreateBigmac createBigmac;
    public Movements snake;
    public Transform segment;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Objects"){
            Destroy(other.gameObject);
            snake.Grow();
            createBigmac.StartCoroutine(createBigmac.createBigmac());
            snake.score++;
        }else if(other.gameObject.tag == "Wall"){
            Debug.Log("t'as tapé un mur");
            // SceneManager.LoadScene(1);
        }else if (other.gameObject.tag == "Magic"){
            Debug.Log("t'as tapé un banane");
            snake.score+=5;
            Destroy(other.gameObject);
            for (int i = 0; i < 5; i++)
            {
                snake.Grow();
            }
            createBigmac.StartCoroutine(createBigmac.createBigmac());
        }else if (other.gameObject.tag == "Sapeur"){
            Debug.Log("t'as tapé un sapeur");
            SceneManager.LoadScene(1);
        }
    }
}
