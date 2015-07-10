using UnityEngine;

public abstract class GhostMovement : MonoBehaviour
{
	public Transform scatterPoint;
	public Transform chasePoint;
	public enum MovementStates { Chase, Scatter, Frightened };
	public MovementStates playerMoveState = MovementStates.Chase;

	protected NavMeshAgent navigation;
	Animator anim;
	
	void Awake ()
	{
		navigation = GetComponent <NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}

	void Start() {
		chasePoint = EnemyMovementManager.Instance.GetRandomChasePoint ();
		Chase ();
	}
	
	void FixedUpdate ()
	{
		if (!GameStateManager.Instance.IsGameOver ()) {
			MoveEnemy ();
		} else {
			navigation.enabled = false;
			anim.SetBool ("Idle", true);
		}
	}

	void MoveEnemy() {
		switch (playerMoveState) {
		case MovementStates.Chase:
			//Chase ();
			break;
		case MovementStates.Scatter: 
			//navigation.SetDestination (scatterPoint.position);
			break;
		case MovementStates.Frightened:
			//
			break;
		}
	}

	protected abstract void Chase();
}
