using UnityEngine;

public class NightmareManMovement : MonoBehaviour
{
	public float speed = 5f;

	Rigidbody nightmareManRigid;
	Animator anim;
	Vector3 movement;
	
	void Awake() {
		nightmareManRigid = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		movement = new Vector3();
	}
	
	void FixedUpdate() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		
		Move (h, v);
		Animation (h, v);
		Turning ();
	}
	
	void Move (float h, float v) {
		if (!isWaking (h, v))
			return;
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
}

