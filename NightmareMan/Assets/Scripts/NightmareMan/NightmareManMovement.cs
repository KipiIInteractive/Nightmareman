using UnityEngine;

public class NightmareManMovement : MonoBehaviour
{
	public float speed = 5f;

	Rigidbody nightmareManRigid;
	Animator anim;
	Vector3 movement;
	float h;
	float v;

	void Awake() {
		nightmareManRigid = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		movement = new Vector3();
	}
	
	void FixedUpdate() {
		HandleMovementEvents ();

		Move (h, v);
		Animation (h, v);
		Turning ();
	}
	
	void Move (float h, float v) {
		movement.Set (h , 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		nightmareManRigid.MovePosition(transform.position + movement);
	}
	
	bool isWaking(float h, float v) {
		return h != 0 || v != 0;
	}
	
	void Animation (float h, float v) {
		anim.SetBool ("IsWalking", isWaking(h, v) );
	}
	
	void Turning() {
		Quaternion rot = new Quaternion();
		rot.SetLookRotation(movement);
		transform.rotation = rot;
	}

	void HandleMovementEvents() {
		float newH = Input.GetAxisRaw ("Horizontal");
		float newV = Input.GetAxisRaw ("Vertical");
		
		if (newH != 0) {
			h = newH;
			v = 0;
		} else if(newV != 0) {
			v =  newV;
			h = 0;
		}
	}
}

