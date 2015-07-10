using UnityEngine;

public class GhostMovement : MonoBehaviour
{
	public Transform nightmareMan;
	public Transform scatterPoint;
	public Transform chasePoint;
	public enum MovementStates { Chase, Scatter, Frightened };
	public MovementStates playerMoveState = MovementStates.Chase;

	NavMeshAgent navigation;
	
	void Awake ()
	{
		navigation = GetComponent <NavMeshAgent> ();
	}

	void Start() {
		chasePoint = EnemyMovementManager.Instance.GetRandomChasePoint ();
	}
	
	void Update ()
	{
		switch (playerMoveState) {
		case MovementStates.Chase:
			navigation.SetDestination (chasePoint.position);
			break;
		case MovementStates.Scatter: 
			navigation.SetDestination (scatterPoint.position);
			break;
		case MovementStates.Frightened:

			break;
		}
	}
}
