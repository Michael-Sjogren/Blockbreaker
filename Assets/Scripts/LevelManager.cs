using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour {


    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void quitRequest()
    {
        Application.Quit();
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
   
    }

    public void isBrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            loadNextLevel();
        }
    }
}
