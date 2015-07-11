using UnityEngine;
using System.Collections;

public class GhostHomicide : GhostMovement {

	bool Bigger(float first, float second) {
		return first > second;
	}

	protected override void Chase() {
		target = EnemyMovementManager.Instance.FindConditionPath (target, player);
		navigation.SetDestination (target.transform.position);
	}

}
