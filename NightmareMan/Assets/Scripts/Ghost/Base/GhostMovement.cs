using UnityEngine;

public abstract class GhostMovement : MonoBehaviour
{
	protected GameObject player;
	protected NavMeshAgent navigation;
	protected bool targetReached = true;
	protected Transform target;

	EnemyMovementManager.MovementStates ghostState;
	Animator anim;
	GameObject scatterPoint;
	
	void Awake ()
	{
		SetScatterPoint ();
		navigation = GetComponent <NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate ()
	{
		switch (GameStateManager.Instance.gameState) {
		case GameStateManager.States.Resume: 		SetInMovement();	break;
		case GameStateManager.States.Pause:			SetInIdle();		break;
		case GameStateManager.States.Lose:			SetInIdle();		break;
		case GameStateManager.States.Win:			SetInIdle();		break;
		default: 									MoveEnemy ();		break;
		}
	}

	void MoveEnemy() {
		if (!targetReached && !StateChanged())
			return;

		ghostState = EnemyMovementManager.Instance.enemyState;

		switch (ghostState) {
		case EnemyMovementManager.MovementStates.Chase: 		Chase ();		break;
		case EnemyMovementManager.MovementStates.Scatter: 		Scatter ();		break;
		case EnemyMovementManager.MovementStates.Frightened:	Frightened();	break;
		}
		targetReached = false;
	}

	public void DisableMovement() {
		navigation.enabled = false;
	}

	void SetInIdle() {
		DisableMovement();
		anim.SetBool ("Idle", true);
	}

	void SetInMovement() {
		EnableMovement ();
		anim.SetBool ("Idle", false);
	}
	
	public void EnableMovement() {
		navigation.enabled = true;
		targetReached = true;
	}

	bool StateChanged() {
		return ghostState != EnemyMovementManager.Instance.enemyState;
	}

	void Scatter() {
		target = EnemyMovementManager.Instance.FindConditionPath (target, scatterPoint);
		navigation.SetDestination (target.transform.position);
	}

	void Frightened() {
		target = EnemyMovementManager.Instance.FindConditionPath (target, player, false);
		navigation.SetDestination (target.transform.position);
	}

	void SetScatterPoint() {
		scatterPoint = GameObject.FindGameObjectWithTag ("ScatterPoint");
		scatterPoint.tag = "Untagged";
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.transform == target) {
			targetReached = true;
		}
	}

	protected abstract void Chase();
}
