using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Movements : MonoBehaviour
{
    public float speed = 30f;
    public float maxX = 10.2f;
    public float minX = -10.2f;
    public float maxY = 4.5f;
    public float minY = -4.5f;
    private string move = "";
    public List<Transform> segments = new List<Transform>();
    [SerializeField] Transform Segment;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.25f;
        segments.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        setMove();
        makeMove();
        //hard mode
        // si on sort de l'écran on meurt
    }

    void FixedUpdate()
    {

        for (int i = segments.Count - 1; i > 0; i--)
        {
            float x = segments[i - 1].position.x;
            float y = segments[i - 1].position.y;
            if (move == "up")
            {
                //rajout pour espace entre les segments rappel pour quand il y aura une grille
                segments[i].position = new Vector2(x, y - 1.2f);
            }else if (move == "down")
            {
                segments[i].position = new Vector2(x, y + 1.2f);
            }else if (move == "left")
            {
                segments[i].position = new Vector2(x + 1.2f, y);
            }else if (move == "right")
            {
                segments[i].position = new Vector2(x - 1.2f, y);
            }
        }
        //mode ez
        ezModeOnExitScreen();
    }

    void setMove()
    {
        switch (Input.inputString)
        {
            case "z":
                move = "up";
                break;
            case "s":
                move = "down";
                break;
            case "q":
                move = "left";
                break;
            case "d":
                move = "right";
                break;
        }
    }

    void makeMove()
    {
        switch (move)
        {
            case "up":
                Vector2 up = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
                transform.position = up;
                break;
            case "down":
                Vector2 down = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
                transform.position = down;
                break;
            case "left":
                Vector2 left = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                transform.position = left;
                break;
            case "right":
                Vector2 right = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                transform.position = right;
                break;
        }
    }

    void ezModeOnExitScreen()
    {
        Vector2 position = transform.position;
        if (position.x > maxX)
        {
            Vector2 left = new Vector2(minX, position.y);
            transform.position = left;
        }
        else if (position.x < minX)
        {
            Vector2 right = new Vector2(maxX, position.y);
            transform.position = right;
        }
        else if (position.y > maxY)
        {
            Vector2 down = new Vector2(position.x, minY);
            transform.position = down;
        }
        else if (position.y < minY)
        {
            Vector2 up = new Vector2(position.x, maxY);
            transform.position = up;
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(Segment);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
}
