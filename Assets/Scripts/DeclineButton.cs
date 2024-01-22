using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeclineButton : MonoBehaviour
{
    public void Decline()
    {
        SceneManager.LoadScene(1);
    }
}
