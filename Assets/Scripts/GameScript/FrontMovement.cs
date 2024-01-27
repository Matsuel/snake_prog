using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontMovement : MonoBehaviour
{
    public GameObject mover;
    private float distance = 1f;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = mover.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (mover.transform.position - lastPosition).normalized;

        if (direction == Vector3.right)
        {
            transform.position = mover.transform.position + direction * distance;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector3.left)
        {
            transform.position = mover.transform.position + direction * distance;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction == Vector3.up)
        {
            transform.position = mover.transform.position + direction * distance;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direction == Vector3.down)
        {
            transform.position = mover.transform.position + direction * distance;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        lastPosition = mover.transform.position;
    }
}
