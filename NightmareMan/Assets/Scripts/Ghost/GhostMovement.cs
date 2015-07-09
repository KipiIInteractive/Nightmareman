using UnityEngine;

public class GhostMovement : MonoBehaviour
{
	public enum MovementStates { Chase, Run, RandomMove };
	public Transform nightmareMan;
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
		case MovementStates.Run: 
			break;
		case MovementStates.RandomMove:
			break;
		}
	}
}
