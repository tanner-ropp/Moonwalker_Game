using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public string levelToLoad;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void LoadLevelFour()
    {
        SceneManager.LoadScene("LevelFour");
    }

    public void Restart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
