using UnityEngine;
using System.Collections;

public class GameStateManager : SingletonManager<GameStateManager> {

	public enum States { Pause, Start, Resume, Win, Lose }
	public States gameState;
	Animator anim;

	new void Awake() {
		base.Awake ();
		InitGameData ();
		anim = GetComponent<Animator> ();
	}

	void Update(){
		if(gameState == States.Lose) {
			anim.SetTrigger("GameOver");
		}
		if(gameState == States.Win) {
			anim.SetTrigger("YouWin");
		}
	}

	void InitGameData() {
		gameState = States.Start;
		SpawnPlayerManager.Instance.SpawnPlayer ();
	}

	public bool IsGameOver() {
		return gameState == States.Win || gameState == States.Lose;
	}
}
