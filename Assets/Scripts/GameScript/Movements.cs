using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class Movements : MonoBehaviour
{
    private float minX = -20.5f;
    private float maxX = 20.5f;
    private float maxY = 9.2f;
    private float minY = -9.2f;
    public int score=0;
    Vector2 direction;
    List<Transform> segments = new List<Transform>();
    public Transform segment;

    public string mode = "ez";

    public Mod mod;
    public AudioSource elevatorMusic;
    public AudioSource tacoMusic;

    void Start()
    {
        mod = GameObject.FindObjectOfType<Mod>();
        if(mod.mode == "hard"){
            mode = "hard";
            elevatorMusic.Play();
            Time.timeScale = 0.25f;
        }else if(mod.mode == "impossible"){
            mode = "impossible";
            tacoMusic.Play();
            Time.timeScale = 0.5f;
        }else{
            mode = "ez";
            elevatorMusic.Play();
            Time.timeScale = 0.25f;
        }
        direction = Vector2.right;
        segments.Add(transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && direction.x != 0)
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && direction.x != 0)
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && direction.y != 0)
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && direction.y != 0)
        {
            direction = Vector2.right;
        }
    }

    void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);

        if (mode == "ez")
        {
            ezModeOnExitScreen();
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.segment);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
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
}
