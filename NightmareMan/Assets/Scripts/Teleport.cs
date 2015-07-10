using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	public Transform otherTeleportPoint;

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			GameObject player = other.gameObject;
			TeleportObject(player);
		}
	}

	void TeleportObject(GameObject player) 
	{
		player.transform.position = otherTeleportPoint.position;
	}
}
