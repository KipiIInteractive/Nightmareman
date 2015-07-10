using UnityEngine;
using System.Collections;

public class GameStateManager : SingletonManager<GameStateManager> {

	public enum States { Pause, Start, Resume, Win, Lose }
	// public States gameState;
	

	void Update()
	{
	
	}

	public bool IsGameOver() {
		return GameObject.FindGameObjectWithTag ("Player") == null;
	}

	// public void PlayAgain(){
	// 	Application.LoadLevel ("Level 01");
	// }
}
