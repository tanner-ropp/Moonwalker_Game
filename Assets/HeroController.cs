using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    Rigidbody rb;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Physics.gravity * -0.015f); // reduce gravity

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(gameObject.transform.up * 10.0f);
            Debug.Log("Up Arrow Key");
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
    }
}
