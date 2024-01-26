using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBigmac : MonoBehaviour
{
    public GameObject bigmac;
    public GameObject sapeur;
    private float minX = -20.5f;
    private float maxX = 20.5f;
    private float maxY = 9.2f;
    private float minY = -9.2f;
    public bool isAlive = true;
    public List<GameObject> bombs = new List<GameObject>();
    public Sprite bigmacSprite;
    public Sprite bananaSprite;
    public Sprite cocacolaSprite;
    private List<Sprite> sprites = new List<Sprite>();
    private bool isBomb = false;
    
    void Start()
    {
        sprites.Add(bigmacSprite);
        sprites.Add(cocacolaSprite);
        StartCoroutine(createBigmac());
    }

    void Update()
    {

    }

    public IEnumerator createBigmac()
    {
        int randomMagic = Random.Range(0, 8);
        if (!isBomb && randomMagic == 5)
        {
            isBomb = true;
            for (int i = 0; i < 5; i++)
            {
                GameObject newBigmac = Instantiate(sapeur);
                newBigmac.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                bombs.Add(newBigmac);
            }
            yield return new WaitForSeconds(2f);
            DestroyBombs();
            isBomb = false;
            StartCoroutine(createBigmac());
        }
        else if (randomMagic == 2 || randomMagic == 7 && !isBomb)
        {
            GameObject newBigmac = Instantiate(bigmac);
            newBigmac.tag = "Magic";
            newBigmac.GetComponent<SpriteRenderer>().sprite = bananaSprite;
            newBigmac.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            yield return new WaitForSeconds(0.5f);
        }
        else if (!isBomb)
        {
            int random = Random.Range(0, 2);
            GameObject newBigmac = Instantiate(bigmac);
            newBigmac.GetComponent<SpriteRenderer>().sprite = sprites[random];
            newBigmac.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void DestroyBombs()
    {
        foreach (GameObject bomb in bombs)
        {
            Destroy(bomb);
        }
        bombs.Clear();
    }
}
