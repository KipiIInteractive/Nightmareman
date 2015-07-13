using UnityEngine;
using System.Collections;

public class GameStateManager : SingletonManager<GameStateManager> {

	public enum States { Pause, Start, Resume, Win, Lose }
	public States gameState;

	enum UpdatesFlags {
		update 		= 1,
		fixedUpdate = 1 << 1
	}
	UpdatesFlags passedUpdates;
	UpdatesFlags allUpdates = UpdatesFlags.fixedUpdate |
					 UpdatesFlags.update;

	new void Awake() {
		base.Awake ();
		InitGameData ();
	}

	void FixedUpdate() {
		if (IsGameResumed ())
			AfterAllUpdates (UpdatesFlags.fixedUpdate);

		if (AllFoodCollected ())
			gameState = States.Win;
	}

	void Update() {
		if (IsGameResumed ())
			AfterAllUpdates (UpdatesFlags.update);

		if (!Input.GetKeyDown ("escape"))
			return;

		passedUpdates = 0;
		gameState = gameState == States.Pause ? States.Resume : States.Pause;
	}

	void AfterAllUpdates(UpdatesFlags newFlag) {
		passedUpdates |= newFlag;
		if(passedUpdates == allUpdates)
			gameState = States.Start;
	}

	void InitGameData() {
		gameState = States.Start;
		SpawnPlayerManager.Instance.SpawnPlayer ();
	}

	public bool AllFoodCollected() {
		return GameObject.FindWithTag ("FoodPoint") == null;
	}

	public bool IsGameOver() {
		return gameState == States.Win || gameState == States.Lose;
	}

	public bool IsGamePaused() {
		return gameState == States.Pause;
	}

	public bool IsGameResumed() {
		return gameState == States.Resume;
	}
}
