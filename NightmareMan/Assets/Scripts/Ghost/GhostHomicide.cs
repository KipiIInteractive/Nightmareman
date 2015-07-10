using UnityEngine;
using System.Collections;

public class GhostHomicide : MonoBehaviour {
	
	GameObject nightmareMan;
	NightmareManMovement nightmareManMovement;
	Animator nightmareManAnim;
	CapsuleCollider nightmareManCapsule;

	Animator GhostAnim;

	void Awake()
	{
		GhostAnim = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			nightmareMan = other.gameObject;

			nightmareManMovement = nightmareMan.GetComponent<NightmareManMovement> ();
			nightmareManAnim = nightmareMan.GetComponent<Animator> ();
			nightmareManCapsule = nightmareMan.GetComponent<CapsuleCollider> ();
			nightmareManMovement.enabled = false;
			nightmareManCapsule.enabled = false;

			nightmareMan.tag = "PlayerDead";
			nightmareManAnim.SetTrigger ("Die");
			GhostAnim.SetTrigger("NightmareManWinOrDie");
		}
	}
}
