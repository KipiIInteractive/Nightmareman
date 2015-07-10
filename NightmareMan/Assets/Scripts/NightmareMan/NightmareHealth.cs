using UnityEngine;
using System.Collections;

public class NightmareHealth : MonoBehaviour {
	public int lives = 2;

	NightmareManMovement nightmareManMovement;
	Animator nightmareManAnim;
	CapsuleCollider nightmareManCapsule;

	void Awake() {
		nightmareManMovement = GetComponent<NightmareManMovement> ();
		nightmareManAnim = GetComponent<Animator> ();
		nightmareManCapsule = GetComponent<CapsuleCollider> ();
	}

	public void TakeDamage() {
		lives -= 1;

		if (lives == 0) { 
			nightmareManAnim.SetTrigger ("Die");
			GameStateManager.Instance.gameState = GameStateManager.States.Lose;

			nightmareManMovement.enabled = false;
			nightmareManCapsule.enabled = false;

			gameObject.tag = "PlayerDead";
		} else {
			SpawnPlayerManager.Instance.Respawn(gameObject);
		}
	}
}
