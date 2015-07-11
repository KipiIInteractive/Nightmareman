using UnityEngine;
using System.Collections;

public class TeleportManager : SingletonManager<TeleportManager> {

	GameObject [] teleportPoints;
		
	void Start() {
		teleportPoints = GameObject.FindGameObjectsWithTag ("TeleportPoint");
	}

	public void TeleportObject(GameObject player) 
	{
		player.transform.position = RandomTeleportPoint().position;
	}

	public Transform RandomTeleportPoint() {
		int index = Random.Range (0, teleportPoints.Length);
		return teleportPoints [index].transform;
	}

}
