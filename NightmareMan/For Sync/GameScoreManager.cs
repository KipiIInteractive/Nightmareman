using UnityEngine;
using System.Collections;

public class GameScoreManager : MonoBehaviour {

	static GameScoreManager Instance { get; set; }
	public int score;

	void Awake() {
		if (Instance != null) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}
	}

}
