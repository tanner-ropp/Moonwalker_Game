using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// all jumpable surfaces should have a collider with the "ground" tag

public class HeroController : MonoBehaviour
{
    Rigidbody rb;
    float speed;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speed = 4.0f;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Physics.gravity * -0.015f); // reduce gravity

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(gameObject.transform.up * 500.0f);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
