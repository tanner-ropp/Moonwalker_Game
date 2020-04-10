using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public string levelToLoad;

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
