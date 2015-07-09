using UnityEngine;

public class GhostMovement : MonoBehaviour
{
	public Transform nightmareMan;
	NavMeshAgent navigation;
	
	void Awake ()
	{
		navigation = GetComponent <NavMeshAgent> ();
	}
	
	void Update ()
	{
		navigation.SetDestination (nightmareMan.position);
	}
}
