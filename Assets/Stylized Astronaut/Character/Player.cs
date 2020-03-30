using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
        public float airSpeed = 1.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;
        public GameObject leftJet, rightJet;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
        
    }

		void Update (){
           
            if (Input.GetKey ("w")) {
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


           Debug.Log(controller.isGrounded ? "GROUNDED" : "NOT GROUNDED");

            if (controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                //moveDirection.y = 0.0f;
                if (Input.GetButtonDown("Fire1"))
                {
                  Debug.Log("Fire1 isGrounded");
                  moveDirection.y = 10f;
                  leftJet.GetComponent<ParticleSystem>().Play();
                  rightJet.GetComponent<ParticleSystem>().Play();
                    StartCoroutine(StopJets());
                }
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        moveDirection.y -= gravity * 0.5f * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
			//dmoveDirection.y -= gravity * 0.5f * Time.deltaTime;
		}

    private void FixedUpdate()
    {
        /*if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * 0.5f * Time.deltaTime;
        } else
        {
            moveDirection.y = 0.0f;
        }*/
        /*float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.fixedDeltaTime, 0);
        controller.Move(moveDirection * Time.fixedDeltaTime);
        moveDirection.y -= gravity * 0.5f * Time.fixedDeltaTime;*/
    }

    IEnumerator StopJets()
    {
        yield return new WaitForSeconds(1.0f);
        leftJet.GetComponent<ParticleSystem>().Stop();
        rightJet.GetComponent<ParticleSystem>().Stop();
    }
}
