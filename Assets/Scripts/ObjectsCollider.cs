using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Objects"){
            // Destroy(other.gameObject);
            Debug.Log("collision");
        }

        Debug.Log("collision with ");
    }
}
