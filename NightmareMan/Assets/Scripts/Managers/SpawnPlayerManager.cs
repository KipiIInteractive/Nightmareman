using UnityEngine;
using System.Collections;

public class SpawnPlayerManager : SingletonManager<SpawnPlayerManager> {

	public GameObject player;
	Transform spawnPoint;

	void Awake() {
		base.Awake ();
		spawnPoint = GameObject.FindGameObjectWithTag ("SpawnPlayerPoint").transform;
		SpawnPlayer ();
	}

	public void SpawnPlayer() {
		Instantiate (player, spawnPoint.position, player.transform.rotation);
	}
	
}
