using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModMenu : MonoBehaviour
{
    public Mod mod;
    // Start is called before the first frame update
    public void PlayEz ()
    {
        mod.mode = "ez";
        SceneManager.LoadScene(0);
    }

    public void PlayHard ()
    {
        mod.mode = "hard";
        SceneManager.LoadScene(0);
    }

    public void PlayImpossible ()
    {
        mod.mode = "impossible";
        SceneManager.LoadScene(0);
    }
}
