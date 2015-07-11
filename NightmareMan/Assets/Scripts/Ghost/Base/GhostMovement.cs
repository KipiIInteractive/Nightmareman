using UnityEngine;

public abstract class GhostMovement : MonoBehaviour
{
	protected GameObject player;
	protected NavMeshAgent navigation;
	protected bool targetReached = true;
	protected Transform target;
	
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
		if (!GameStateManager.Instance.IsGameOver ()) {
			MoveEnemy ();
		} else {
			navigation.enabled = false;
			anim.SetBool ("Idle", true);
		}
	}

	void MoveEnemy() {
		if (!targetReached)
			return;

		var state = EnemyMovementManager.Instance.enemyState;

		switch (state) {
		case EnemyMovementManager.MovementStates.Chase:
			Chase ();
			break;
		case EnemyMovementManager.MovementStates.Scatter: 
			Scatter ();
			break;
		case EnemyMovementManager.MovementStates.Frightened:
			Frightened();
			break;
		}
		targetReached = false;
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
