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

           

           

            if (controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                if (Input.GetButtonDown("Fire1"))
                {
                  Debug.Log("Fire1 isGrounded");
                  moveDirection.y = 10f;
                }
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * 0.5f * Time.deltaTime;
		}
}
