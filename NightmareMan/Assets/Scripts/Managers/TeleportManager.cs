using UnityEngine;
using System.Collections;

public class TeleportManager : MonoBehaviour {
	// Not a singleton manager, not a manager
	public Transform otherTeleportPoint;

	Rigidbody NightmareManRigid;
	bool NightmareManInRange = false;

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player" && !NightmareManInRange)
		{
			NightmareManRigid = other.gameObject.GetComponent<Rigidbody> ();
			NightmareManInRange = true;
			Teleport();
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			NightmareManInRange = false;
		}
	}


	void Teleport() 
	{
		NightmareManRigid.transform.position = otherTeleportPoint.position;
	}
}
