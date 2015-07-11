using UnityEngine;
using System.Collections;

public class EnemyMovementManager : SingletonManager<EnemyMovementManager> {

	public GameObject [] chasePoints;
	public enum MovementStates { Chase, Scatter, Frightened };
	public MovementStates enemyState = MovementStates.Chase;
	
	new void Awake() {
		base.Awake ();
		chasePoints = GameObject.FindGameObjectsWithTag ("EnemyMovementPoint");
	}

	public Transform RandomChasePoint() {
		int index = Random.Range (0, chasePoints.Length);
		return chasePoints [index].transform;
	}

	public Transform FindConditionPath(Transform currentPosition, GameObject target, bool shortest = true) {
		Transform shortestPath = null;
		float shortestDistance = shortest ? Mathf.Infinity : 0;
		foreach(GameObject chasePoint in chasePoints) {
			if(chasePoint.transform == currentPosition) 
				continue;

			float currentIterationDist = Vector3.Distance(chasePoint.transform.position, target.transform.position);
			if(shortestDistance > currentIterationDist == shortest) {
				shortestPath = chasePoint.transform;
				shortestDistance = currentIterationDist;
			}
		}

		return shortestPath;
	}

}
