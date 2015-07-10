using UnityEngine;
using System.Collections;

public class GameStateManager : SingletonManager<GameStateManager> {

	public enum States { Pause, Start, Resume, Win, Lose }
	public States gameState;

	new void Awake() {
		base.Awake ();
		InitGameData ();
	}

	void InitGameData() {
		gameState = States.Start;
		SpawnPlayerManager.Instance.SpawnPlayer ();
	}

	public bool IsGameOver() {
		return gameState == States.Win || gameState == States.Lose;
	}
}
