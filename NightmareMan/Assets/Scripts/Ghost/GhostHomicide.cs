using UnityEngine;
using System.Collections;

public class GhostHomicide : GhostMovement {

	Vector3 currentLocation = Vector3.zero;

	protected override void Chase() {
		Vector3 nextLocation;

		do {
			nextLocation = EnemyMovementManager.Instance.GetRandomChasePoint ().position;
		} while( nextLocation.Equals(currentLocation) );

		currentLocation = nextLocation;
		navigation.SetDestination (currentLocation);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.transform.position == currentLocation) {
			Chase ();
		}
	}

}
