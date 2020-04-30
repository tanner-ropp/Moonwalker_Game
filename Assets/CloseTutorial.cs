using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorial : MonoBehaviour
{
    bool clicked;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

    }

    public void closeIt()
    {
        clicked = true;
        Cursor.visible = false;
        canvas.SetActive(false);
    }
}
