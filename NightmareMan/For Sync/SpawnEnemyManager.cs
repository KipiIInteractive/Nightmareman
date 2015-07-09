using UnityEngine;
using System.Collections;

public class SpawnEnemyManager : MonoBehaviour {
	
	public Transform spawnPoint;
	public static SpawnEnemyManager Instance;
	
	void Start() {
		if (Instance != null) {
			Destroy(gameObject);
		} else {
			Instance = this;
		}
	}
	
}
