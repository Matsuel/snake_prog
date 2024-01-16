using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCollider : MonoBehaviour
{
    public CreateBigmac createBigmac;
    public Movements movements;
    public Transform segment;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Objects"){
            Destroy(other.gameObject);
            createBigmac.bigmacs.Remove(other.gameObject);
            movements.Grow();
        }
        // else if (other.gameObject.tag=="Segment"){
        //     // Debug.Log("t'as perdu");
        //     // C'est là qu'on changerz la scène
        // }
    }
}
