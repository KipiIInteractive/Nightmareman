using UnityEngine;

public class GhostMovement : MonoBehaviour
{
	public Transform nightmareMan;
	public Transform scatterPoint;
	public enum MovementStates { Chase, Scatter, Frightened };
	public MovementStates playerMoveState = MovementStates.Chase;

	NavMeshAgent navigation;
	
	void Awake ()
	{
		navigation = GetComponent <NavMeshAgent> ();
	}
	
	void Update ()
	{
		switch (playerMoveState) {
		case MovementStates.Chase:
			navigation.SetDestination (nightmareMan.position);
			break;
		case MovementStates.Scatter: 
			navigation.SetDestination (scatterPoint.position);
			break;
		case MovementStates.Frightened:

			break;
		}
	}
}
