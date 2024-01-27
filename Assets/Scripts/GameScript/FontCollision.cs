using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FontCollision : MonoBehaviour
{
    public Transform segment;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Segment" && this.gameObject.tag=="Front"){
            Debug.Log("t'as perdu ct ton corps");
            SceneManager.LoadScene(1);
        }
    }
}
