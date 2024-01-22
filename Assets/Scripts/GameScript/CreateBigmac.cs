using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBigmac : MonoBehaviour
{
    public GameObject bigmac;
    private float minX = -21f;
    private float maxX = 21f;
    private float maxY = 10f;
    private float minY = -10f;
    public bool isAlive = true;
    public List<GameObject> bigmacs = new List<GameObject>();
    public List<GameObject> bigmacsToDestroy = new List<GameObject>();

    public Sprite bigmacSprite;
    public Sprite bananaSprite;
    public Sprite cocacolaSprite;
    private List<Sprite> sprites = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        sprites.Add(bigmacSprite);
        sprites.Add(bananaSprite);
        sprites.Add(cocacolaSprite);
        StartCoroutine(createBigmac());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator createBigmac()
    {
        int random = Random.Range(0, 3);
        GameObject newBigmac = Instantiate(bigmac);
        newBigmac.GetComponent<SpriteRenderer>().sprite = sprites[random];
        newBigmac.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        bigmacs.Add(newBigmac);
        yield return new WaitForSeconds(0.5f);
    }
}
