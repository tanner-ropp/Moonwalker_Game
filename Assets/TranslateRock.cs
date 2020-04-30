using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateRock : MonoBehaviour
{

    private Vector3 pos;
    private Vector3 newpos;
    public float x_direction;
    public float y_direction;
    public float z_direction;

    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;

        newpos = new Vector3(transform.position.x + x_direction, transform.position.y + y_direction, transform.position.z + z_direction);
    Debug.Log("pos is " + pos);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(pos, newpos, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
