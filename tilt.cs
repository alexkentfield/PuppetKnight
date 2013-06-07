using UnityEngine;
using System.Collections;
using System;

public class tilt : MonoBehaviour {
	
		public AudioClip running;
		private bool hasPlayed;
		public Quaternion targetRotation;
		CharacterController cc;
	
	void Start () {
		cc = gameObject.GetComponent<CharacterController>();
		hasPlayed = false;
		targetRotation = Quaternion.Euler(0,0, 0);
	
	}
	
	void Update () {

		if (PlayerHealth.alive)
		{
				MovePlayer();
				RotatePlayer();
		}
		
	}
	
	void MovePlayer() {   
		
		//if (Input.acceleration.y > -0.6)
		if (Input.GetKey(KeyCode.W))
		{
			Vector3 forward = cc.transform.forward;	
			forward *= 2.7f;
			forward.y = 0.0f;	
			cc.Move(forward * Time.deltaTime);
			if (PlayerAttack.isPlayerAttacking == false)
			{
				animation.CrossFade("Run", 0.2f);
			}
		}
		else if (Input.GetKey(KeyCode.S)	)
		{
			Vector3 backward = -cc.transform.forward;	
			backward *= 2.7f;
			backward.y = 0.0f;
			cc.Move(backward * Time.deltaTime);
			if (PlayerAttack.isPlayerAttacking == false)
			{
				animation.CrossFade("Walk", 0.2f);
			}
		}
		else
		{
			hasPlayed = false;
			if (PlayerAttack.isPlayerAttacking == false)
			{
				animation.CrossFade("Idle", 0.2f);
			}
		}
    }

	void RotatePlayer() {
        
		if (Input.GetKey(KeyCode.A)	)
		{
			targetRotation = Quaternion.Euler(0,-0.8f + transform.rotation.eulerAngles.y, 0);	
		}
		
		if (Input.GetKey(KeyCode.D)	)
		{
			targetRotation = Quaternion.Euler(0,0.8f + transform.rotation.eulerAngles.y, 0);	
		}
		transform.rotation = targetRotation;
	}
	
	void playRunningSound() {

    	if(!hasPlayed){
        	audio.PlayOneShot(running);
        	hasPlayed = true;
    }
}
	
}

