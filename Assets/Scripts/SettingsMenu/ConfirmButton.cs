using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmButton : MonoBehaviour
{
    public void Confirm()
    {
        SceneManager.LoadScene(1);
    }
}
