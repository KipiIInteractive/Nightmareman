using UnityEngine;
using System.Collections;

public class SpawnPelletManager : MonoBehaviour {
	
	public Transform spawnPoint;
	public static SpawnPelletManager Instance;
	
	void Start() {
		if (Instance != null) {
			Destroy(gameObject);
		} else {
			Instance = this;
		}
	}
}

