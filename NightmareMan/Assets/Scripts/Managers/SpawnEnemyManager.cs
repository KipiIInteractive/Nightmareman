using UnityEngine;
using System.Collections;

public class SpawnEnemyManager : SingletonManager<SpawnEnemyManager> {

	public GameObject enemy;

	Transform spawnPoint;

	new void Awake() {
		base.Awake ();
		spawnPoint = GameObject.FindGameObjectWithTag ("SpawnEnemyPoint").transform;
		SpawnEnemy ();
	}
	
	public void SpawnEnemy() {
		Instantiate (enemy, spawnPoint.position, enemy.transform.rotation);
	}

	public void Respawn(GameObject enemy) {
		enemy.transform.position = spawnPoint.position;
	}

}
