using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

	public static GameStateManager Instance { get; set; } 
	public enum States { Pause, Start, Resume, Win, Lose }
	public States State;

	void Awake () {
		if (Instance != null) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}
	}
}
