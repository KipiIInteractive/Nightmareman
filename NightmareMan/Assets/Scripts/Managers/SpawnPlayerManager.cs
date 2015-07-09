using UnityEngine;
using System.Collections;

public class SpawnPlayerManager : MonoBehaviour {

	public Transform spawnPoint;
	public static SpawnPlayerManager Instance;

	void Start() {
		if (Instance != null) {
			Destroy(gameObject);
		} else {
			Instance = this;
		}
	}

}
