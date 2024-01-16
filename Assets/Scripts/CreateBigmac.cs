using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBigmac : MonoBehaviour
{
    public GameObject bigmac;
    public float maxX = 10.2f;
    public float minX = -10.2f;
    public float maxY = 4.5f;
    public float minY = -4.5f;
    public bool isAlive = true;
    List<GameObject> bigmacs = new List<GameObject>();
    List<GameObject> bigmacsToDestroy = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createBigmac());
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator createBigmac(){
        while(isAlive){
            yield return new WaitForSeconds(4f);
            GameObject newBigmac = Instantiate(bigmac);
            // Debug.Log(newBigmac.GetComponent<Renderer>().bounds.size);
            newBigmac.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            bigmacs.Add(newBigmac);
        }
    }
}
