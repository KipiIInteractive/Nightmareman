using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemyManager : SingletonManager<SpawnEnemyManager> {

	public List<GameObject> enemy;
	public int spawnIntervalSeconds = 4;
	static int count = 0;
	Transform spawnPoint;

	new void Awake() {
		base.Awake ();
		spawnPoint = GameObject.FindGameObjectWithTag ("SpawnEnemyPoint").transform;
		for(int i = 0; i < enemy.Count; i++)
			Invoke( "SpawnEnemy", spawnIntervalSeconds*i);
	}
	
	public void SpawnEnemy() { 
		Instantiate (enemy[count], spawnPoint.position, enemy[count].transform.rotation);
		count++;
	}

	public void Respawn(GameObject enemy) {
		enemy.transform.position = spawnPoint.position;
	}
}
