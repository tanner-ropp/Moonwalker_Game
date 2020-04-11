using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktoStartScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Application.LoadLevel("SampleLevel");

        }
    }
}
