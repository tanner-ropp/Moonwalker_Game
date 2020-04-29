using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    bool dead = false;
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;
    public GameObject deathZone;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 1000.0f;
    private float sensitivityY = 20.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        if (!dead)
        {
            currentX += Input.GetAxis("Mouse X");
            currentY -= Input.GetAxis("Mouse Y");
            //currentX

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
        else
        {
            if (currentY < 90.0f)
            {
                currentY += 1.0f;
            }
            
            //distance += 1;
        }
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        
        if (!dead)
        {
            Quaternion rotation = Quaternion.Euler(currentY, currentX * 3.0f, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);
        }
        else
        {
            //Quaternion rotation = Quaternion.Euler(currentY, 0, 0);
            //camTransform.position = lookAt.position + rotation * dir;
            gameObject.transform.parent = null;
            if (currentY < 90.0f)
            {
                camTransform.LookAt(lookAt.position);
            }

            if (camTransform.position.y < deathZone.transform.position.y + 75.0f)
            {
                camTransform.position = new Vector3(camTransform.position.x, camTransform.position.y + 0.4f, camTransform.position.z);
            }
            else
            {
                //camTransform.position = new Vector3(camTransform.position.x, deathZone.transform.position.y + 100.0f, camTransform.position.z);
            }
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DeathZone")
        { 
            dead = true;
        }
    }
}
