using UnityEngine;
using System.Collections;

public class SpawnDotManager : MonoBehaviour {
	
	public Transform spawnPoint;
	public static SpawnDotManager Instance;
	
	void Start() {
		if (Instance != null) {
			Destroy(gameObject);
		} else {
			Instance = this;
		}
	}
}

