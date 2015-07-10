using UnityEngine;
using System.Collections;

public class SpawnEnemyManager : SingletonManager<SpawnEnemyManager> {

	public GameObject enemy;

	Transform spawnPoint;

	void Awake() {
		base.Awake ();
		spawnPoint = GameObject.FindGameObjectWithTag ("SpawnEnemyPoint").transform;
		SpawnEnemy ();
	}
	
	public void SpawnEnemy() {
		Instantiate (enemy, spawnPoint.position, enemy.transform.rotation);
	}

}
