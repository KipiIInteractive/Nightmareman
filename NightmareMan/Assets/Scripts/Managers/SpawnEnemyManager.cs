using UnityEngine;
using System.Collections;

public class SpawnEnemyManager : SingletonManager<SpawnEnemyManager> {

	public GameObject enemy;
	public int numberOfZombies 		= 4;
	public int spawnIntervalSeconds = 4;

	Transform spawnPoint;

	new void Awake() {
		base.Awake ();
		spawnPoint = GameObject.FindGameObjectWithTag ("SpawnEnemyPoint").transform;
		for(int i = 0; i < numberOfZombies; i++)
			Invoke("SpawnEnemy", spawnIntervalSeconds*i);
	}
	
	public void SpawnEnemy() {
		Instantiate (enemy, spawnPoint.position, enemy.transform.rotation);
	}

	public void Respawn(GameObject enemy) {
		enemy.transform.position = spawnPoint.position;
	}

}
