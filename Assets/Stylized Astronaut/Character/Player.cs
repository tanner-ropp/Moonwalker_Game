using UnityEngine;
using System.Collections;
//using System;

public class Player : MonoBehaviour {


		private Animator anim;
		private CharacterController controller;

        public AudioSource myAudio;
        public AudioClip[] jumps;

		public float speed = 600.0f;
        public float airSpeed = 1.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;
        public GameObject leftJet, rightJet;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
        Cursor.visible = false;
        
    }

		void Update (){
        Cursor.lockState = CursorLockMode.Confined;
            float turn = Input.GetAxis("Horizontal");
        //Debug.Log(turn);

            if (Input.GetKey ("w") || Input.GetKey("a") || Input.GetKey("d"))  {
                if (!controller.isGrounded)
                { 
                    controller.Move(transform.forward * airSpeed * Time.deltaTime);
                }
                else
                {
                    //leftJet.GetComponent<ParticleSystem>().Stop();
                    //rightJet.GetComponent<ParticleSystem>().Stop();
                }
                anim.SetInteger ("AnimationPar", 1);
			}  else {
                //leftJet.GetComponent<ParticleSystem>().Stop();
                //rightJet.GetComponent<ParticleSystem>().Stop();
                anim.SetInteger ("AnimationPar", 0);
                
			}


           //Debug.Log(controller.isGrounded ? "GROUNDED" : "NOT GROUNDED");

            if (controller.isGrounded){

                anim.SetInteger("JumpPar", 0);
				moveDirection = transform.forward * System.Math.Max(Input.GetAxis("Vertical"),System.Math.Abs(Input.GetAxis("Horizontal"))) * speed;
                //moveDirection.y = 0.0f;
                if (Input.GetButtonDown("Fire1"))
                {
                myAudio.PlayOneShot(jumps[Random.Range(0,3)]);
                anim.SetInteger("JumpPar", 1);
                  //Debug.Log("Fire1 isGrounded");
                  moveDirection.y = 10f;
                  leftJet.GetComponent<ParticleSystem>().Play();
                  rightJet.GetComponent<ParticleSystem>().Play();
                  StartCoroutine(StopJets());
                }
			}

            
            //float turn = 0.0f;
            //transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            transform.Rotate(0, turn * 90, 0);

            //if (!controller.isGrounded || )
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);

            if (turn > 0.01f || turn < -0.01f)
            {
                //moveDirection = transform.forward * speed;
                anim.SetInteger("AnimationPar", 1);
            }

            moveDirection.y -= gravity * 0.5f * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
			//dmoveDirection.y -= gravity * 0.5f * Time.deltaTime;
		}

    IEnumerator StopJets()
    {
        yield return new WaitForSeconds(1.0f);
        leftJet.GetComponent<ParticleSystem>().Stop();
        rightJet.GetComponent<ParticleSystem>().Stop();
    }
}
